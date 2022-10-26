﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using CCU.Traits;
using HarmonyLib;
using RogueLibsCore;
using UnityEngine.UI;

namespace CCU.Patches.Inventory
{
	[HarmonyPatch(declaringType: typeof(CharacterCreation))]
	public static class P_CharacterCreation
	{
		private static readonly ManualLogSource logger = CCULogger.GetLogger();
		public static GameController GC => GameController.gameController;

        // This originally did both auto-sorting of traits as well as exclusion of CCU Traits. Auto-sorting is moved to SORQUOL. CCU filtering should be redone here.
        [HarmonyTranspiler, HarmonyPatch(methodName: nameof(CharacterCreation.CreatePointTallyText))]
        private static IEnumerable<CodeInstruction> CreatePointTallyText_FilterCCPCount(IEnumerable<CodeInstruction> codeInstructions)
        {
            List<CodeInstruction> instructions = codeInstructions.ToList();
            FieldInfo traitsChosen = AccessTools.DeclaredField(typeof(CharacterCreation), nameof(CharacterCreation.traitsChosen));
            MethodInfo playerUnlockList = AccessTools.DeclaredMethod(typeof(T_CCU), nameof(T_CCU.PlayerUnlockList), parameters: new Type[] { typeof(List<Unlock>) });
            MethodInfo autoSortTraitsChosen = AccessTools.DeclaredMethod(typeof(P_CharacterCreation), nameof(P_CharacterCreation.AutoSortTraitsChosen));

            CodeReplacementPatch patch = new CodeReplacementPatch(
                expectedMatches: 2,
                prefixInstructionSequence: new List<CodeInstruction>
                {
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Ldfld, traitsChosen)
                },
                targetInstructionSequence: new List<CodeInstruction>
                {

                },
                insertInstructionSequence: new List<CodeInstruction>
                {
                    new CodeInstruction(OpCodes.Call, playerUnlockList),
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Call, autoSortTraitsChosen),
                },
                postfixInstructionSequence: new List<CodeInstruction>
                {
                    new CodeInstruction(OpCodes.Callvirt),
                    new CodeInstruction(OpCodes.Stloc_S, 12),
                });

            patch.ApplySafe(instructions, logger);
            return instructions;
        }
        private static void AutoSortTraitsChosen(CharacterCreation characterCreation)
        {
            if (characterCreation.sortByName)
                characterCreation.traitsChosen = T_CCU.SortUnlocksByName(characterCreation.traitsChosen);
            else
                characterCreation.traitsChosen = T_CCU.SortUnlocksByValue(characterCreation.traitsChosen);
        }

        [HarmonyTranspiler, HarmonyPatch(methodName: nameof(CharacterCreation.CreatePointTallyText))]
		private static IEnumerable<CodeInstruction> CreatePointTallyText_CustomCCUSection(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo itemsChosen = AccessTools.DeclaredField(typeof(CharacterCreation), nameof(CharacterCreation.itemsChosen));
			MethodInfo printTraitList = AccessTools.DeclaredMethod(typeof(P_CharacterCreation), nameof(P_CharacterCreation.PrintTraitList));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				expectedMatches: 1,
				prefixInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
				},
				targetInstructionSequence: new List<CodeInstruction>
				{

				},
				insertInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Call, printTraitList),
					new CodeInstruction(OpCodes.Ldarg_0), // Replace original
				},
				postfixInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldfld, itemsChosen),
					new CodeInstruction(OpCodes.Callvirt),
					new CodeInstruction(OpCodes.Ldc_I4_0),
					new CodeInstruction(OpCodes.Ble_S),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
		public static void PrintTraitList(CharacterCreation characterCreation)
        {
			if (T_CCU.DesignerUnlockList(characterCreation.traitsChosen).Any())
				characterCreation.pointTallyText.text += "\n<color=yellow>- CCU TRAITS -</color>\n";
			else
				return;

			foreach (Unlock unlock in T_CCU.SortUnlocksByName(T_CCU.DesignerUnlockList(characterCreation.traitsChosen).Where(u => !T_CCU.IsPlayerUnlock(u)).ToList()))
            {
				string traitName = GC.nameDB.GetName(unlock.unlockName, "StatusEffect") + "\n";
				traitName = traitName.Replace("[CCU] ", "");
				characterCreation.pointTallyText.text += traitName;
			}
		}
	}
} 