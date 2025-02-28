﻿using CCU.Traits.App_SC1;
using RogueLibsCore;

namespace CCU.Traits.App_SC2
{
	public class Shapeshifter_Skin : T_SkinColor
	{
		// The double-presence of the WhiteSkin string is to mirror the vanilla code.
		// I'm not a huge fan of it, but complaints go to Matt, not to me.
		public override string[] Rolls => 
			new string[] { "WhiteSkin", "WhiteSkin", "PinkSkin", "PaleSkin", "MixedSkin" };

		[RLSetup]
		public static void Setup()
		{
			PostProcess = RogueLibs.CreateCustomTrait<Shapeshifter_Skin>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Adds multiple items to the appearance pool.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DesignerName(typeof(Shapeshifter_Skin)),
				})
				.WithUnlock(new TraitUnlock_CCU
				{
					CharacterCreationCost = 0,
					IsAvailable = false,
					IsAvailableInCC = Core.designerEdition,
					UnlockCost = 0,
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
