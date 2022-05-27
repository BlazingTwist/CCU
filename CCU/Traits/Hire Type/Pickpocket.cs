﻿using RogueLibsCore;
using SORCE.Localization;

namespace CCU.Traits.Hire_Type
{
    public class Pickpocket : T_HireType
    {
        public override string HiredActionButtonText => CJob.Pickpocket;
        public override string HireButtonText => VButtonText.Hire_Expert;
        public override object HireCost => VDetermineMoneyCost.Hire_Thief;

        //[RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Pickpocket>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "This character can be hired to pick someone's pockets.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Pickpocket)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { },
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
