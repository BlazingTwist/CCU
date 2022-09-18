﻿using CCU.Traits.App_BT1;
using RogueLibsCore;

namespace CCU.Traits.App_BT2
{
	public class Mech_Body_Greyscale : T_BodyType
    {
		public override string[] Rolls => new string[] { "Mech" };

        [RLSetup]
		public static void Setup()
		{
			PostProcess = RogueLibs.CreateCustomTrait<Mech_Body_Greyscale>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Adds this item to the appearance pool.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DesignerName(typeof(Mech_Body_Greyscale)),
				})
				.WithUnlock(new TraitUnlock
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
