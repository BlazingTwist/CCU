﻿using CCU.Localization;
using RogueLibsCore;
using System;

namespace CCU.Traits.Drug_Warrior
{
    public class Number_to_Pain : T_DrugWarrior
    {
        public override string DrugEffect => VStatusEffect.ResistDamageMedium;

        [RLSetup]
        public static void Setup()
        {
            PostProcess = RogueLibs.CreateCustomTrait<Number_to_Pain>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = String.Format("This character gains a 33% damage resistance upon entering combat."),
                    
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DesignerName(typeof(Number_to_Pain)),
                    
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
