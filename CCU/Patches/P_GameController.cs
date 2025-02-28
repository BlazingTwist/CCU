﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using BepInEx.Logging;
using UnityEngine.UI;
using CCU.Localization;
using CCU.Challenges;

namespace CCU.Patches
{
	[HarmonyPatch(declaringType: typeof(GameController))]
	public static class P_GameController
	{
		private static readonly ManualLogSource logger = CCULogger.GetLogger();
		public static GameController GC => GameController.gameController;


        // Just make sure what you're accessing exists here to avoid errors
        [HarmonyPostfix, HarmonyPatch(methodName: "Awake",
            argumentTypes: new Type[0] { })]
        public static void Awake_Postfix()
        {
            List<string> removals = new List<string>();

            foreach (string challenge in GC.sessionDataBig.challenges)
            {
                logger.LogDebug(challenge);

                if (Legacy.ChallengeConversions.ContainsKey(challenge))
                    removals.Add(challenge);
            }

            foreach (string removal in removals)
            {
                GC.sessionDataBig.challenges.Remove(removal);
                string replacement = Legacy.ChallengeConversions[removal].Name;
                logger.LogDebug("Replacement: " + replacement);
                GC.sessionDataBig.challenges.Add(replacement);
            }
        }

        //[HarmonyPostfix, HarmonyPatch(methodName: nameof(GameController.SetFont), argumentTypes: new[] { typeof(Text) })]
        //public static void SetFont_Postfix(Text myText)
        //{
        //    // This works, but only for non-english languages
        //    myText.color = new UnityEngine.Color(255f, 0f, 0f);
        //}
    }
}
