﻿using BepInEx.Logging;
using CCU.Localization;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCU.Systems.Investigateables
{
    public static class Investigateables
	{
		private static readonly ManualLogSource logger = CCULogger.GetLogger();
		public static GameController GC => GameController.gameController;

		public static string ExtraVarStringPrefix = "investigateable-message:::";

		public static List<string> InvestigateableObjects_Slot1 = new List<string>()
		{
			vObject.Altar,
			vObject.ArcadeGame,
			vObject.Boulder,
			vObject.Computer,
			// vObject.Counter,		// Really needs a sprite change
			vObject.Gravestone,
			vObject.Jukebox,
			// vObject.MovieScreen, // Didn't work yet, see notes
			vObject.Podium,
			vObject.Speaker,
			vObject.Television,
			vObject.Window,
		};
		public static List<string> InvestigateableObjects_Slot2 = new List<string>()
		{
			//vObject.Door,
			//vObject.Shelf,
		};

		public static string MagicObjectName(string originalName) =>
			IsInvestigateable(originalName)
				? vObject.Sign
				: originalName;

		public static bool IsInvestigateable(string name) =>
			InvestigateableObjects_Slot1.Contains(name) ||
			InvestigateableObjects_Slot2.Contains(name);

		public static bool IsInvestigationString(string name) =>
			!(name is null) &&
			name != "" &&
			(
				name.StartsWith(ExtraVarStringPrefix) || 
				name.EndsWith(ExtraVarStringPrefix) ||
				name == ExtraVarStringPrefix ||
				name == ExtraVarStringPrefix + Environment.NewLine
			);

		public static List<InvSlot> FilteredSlots(InvDatabase invDatabase) =>
			invDatabase.agent.mainGUI.invInterface.Slots.Where(islot => !IsInvestigationString(islot.itemNameText.text)).ToList();

		public static InvDatabase FilteredInvDatabase(InvDatabase invDatabase)
		{
			invDatabase.InvItemList = FilteredInvItemList(invDatabase.InvItemList);
			return invDatabase;
		}

		public static List<InvItem> FilteredInvItemList(List<InvItem> invItemList) =>
			invItemList.Where(ii => !IsInvestigationString(ii.invItemName)).ToList();

		[RLSetup]
		public static void Setup()
		{
			string t = NameTypes.Interface;

			RogueLibs.CreateCustomName(CButtonText.Investigate, t, new CustomNameInfo(CButtonText.Investigate));

			RogueInteractions.CreateProvider(h =>
			{
				if (!h.Agent.interactionHelper.interactingFar &&
					IsInvestigateable(h.Object.objectName) &&
					IsInvestigationString(h.Object.extraVarString))
				{
					string text = h.Object.extraVarString.Remove(0, ExtraVarStringPrefix.Length + 2);

					if (text.Length is 0) // idk how do you even detect real content
						return;

					if (h.Object is Computer computer)
						h.RemoveButton(VButtonText.ReadEmail);

					h.AddButton(CButtonText.Investigate, m =>
					{
						logger.LogDebug("Text:\n\t'" + text + "'");
						m.Object.ShowBigImage(text, "", null);
					});
				}
			});
		}
	}
}