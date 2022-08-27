﻿using RogueLibsCore;
using System;
using System.Collections.Generic;

namespace CCU.Traits.Merchant_Type
{
    public class Consumer_Electronics : T_MerchantType
    {
        public override List<KeyValuePair<string, int>> MerchantInventory => new List<KeyValuePair<string, int>>()
        {
            new KeyValuePair<string, int>( vItem.BoomBox, 2),
            new KeyValuePair<string, int>( vItem.FoodProcessor, 1),
            new KeyValuePair<string, int>( vItem.FriendPhone, 2),
            new KeyValuePair<string, int>( vItem.MiniFridge, 1),
            new KeyValuePair<string, int>( vItem.Translator, 2),
            new KeyValuePair<string, int>( vItem.WalkieTalkie, 1),
        };

        [RLSetup]
        public static void Setup()
        {
            PostProcess = RogueLibs.CreateCustomTrait<Consumer_Electronics>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = String.Format("This character sells consumer electronics and appliances."),
                    
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DesignerName(typeof(Consumer_Electronics)),
                    
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
