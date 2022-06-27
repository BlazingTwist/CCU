﻿using RogueLibsCore;
using System;

namespace CCU.Traits.Passive
{
    public class Status_Effect_Immune : T_CCU
    {
        [RLSetup]
        public static void Setup()
        {
            PostProcess = RogueLibs.CreateCustomTrait<Status_Effect_Immune>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = String.Format("This character is immune to all status effects... but they still have feelings."),
                    
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Status_Effect_Immune)),
                    
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