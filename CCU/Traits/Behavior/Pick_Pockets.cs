﻿using RogueLibsCore;

namespace CCU.Traits.Behavior
{
    /// <summary>
    /// Don't rename this: needs to be distinct from Hire trait name
    /// </summary>
    public class Pick_Pockets : T_Behavior
    {
        public override bool LosCheck => true;
        public override string[] GrabItemCategories => null;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Pick_Pockets>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = string.Format("This character will pickpocket like the Thief.\n\n<color=red>Requires:</color> {0}", vSpecialAbility.StickyGlove),
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Pick_Pockets)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { DisplayName(typeof(Eat_Corpses)), DisplayName(typeof(Suck_Blood)) },
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
