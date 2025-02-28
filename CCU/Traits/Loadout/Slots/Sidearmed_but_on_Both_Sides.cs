﻿using CCU.Traits.Loadout;
using RogueLibsCore;

namespace CCU.Traits.Loadout_Slots
{
    internal class Sidearmed_but_on_Both_Sides : T_Loadout
    {
		[RLSetup]
		public static void Setup()
		{
			PostProcess = RogueLibs.CreateCustomTrait<Sidearmed_but_on_Both_Sides>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Allows two additional equippable items within the same slot to be generated in inventory.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DesignerName(typeof(Sidearmed_but_on_Both_Sides)),
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