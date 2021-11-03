﻿using BepInEx.Logging;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCU.Traits.TraitTrigger
{
    public class TraitTrigger_CoolCannibal : CustomTrait
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<TraitTrigger_CoolCannibal>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = String.Format("This NPC's behaviors will react to the player's Cool with Cannibals trait.\n\n<color=green>{0}</color>, <color=green>{1}</color>, <color=green>{2}:</color> Will not target the player if they have Cool with Cannibals.\n\n<color=green>{3}:</color> Will not sell wares unless player has Cool With Cannibals.", CTrait.Spawn_HideInBush, CTrait.Spawn_HideInManhole, CTrait.Relationships_AggressiveCannibal, CTrait.MerchantType_Anthropophagie),
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = CTrait.TraitTrigger_CoolCannibal,
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
