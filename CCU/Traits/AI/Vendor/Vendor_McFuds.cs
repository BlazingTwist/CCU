﻿using RogueLibsCore;
using System;

namespace CCU.Traits.AI.Vendor
{
    public class Vendor_McFuds : CustomTrait
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Vendor_McFuds>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = String.Format("This character sells Fud & Hot Fud."),
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = CTrait.Vendor_McFuds,
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
