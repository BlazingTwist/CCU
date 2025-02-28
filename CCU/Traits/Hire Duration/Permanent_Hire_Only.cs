﻿using RogueLibsCore;

namespace CCU.Traits.Hire_Duration
{
    public class Permanent_Hire_Only : T_HireDuration
    {
        [RLSetup]
        public static void Setup()
        {
            PostProcess = RogueLibs.CreateCustomTrait<Permanent_Hire_Only>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Offers Permanent Hire, AND removes the regular hire option.\n\n" +
                        "Permanent Hires can use their Expert ability unlimited times, and will ignore Homesickness.\n\n" +
                        "<color=red>Requires:</color> Any Hire Type trait",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DesignerName(typeof(Permanent_Hire_Only)),
                })
                .WithUnlock(new TraitUnlock_CCU
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
