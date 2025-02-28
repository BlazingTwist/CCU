﻿using RogueLibsCore;
using System;
using System.Collections.Generic;

namespace CCU.Traits.Merchant_Type
{
    public class Home_Fortress_Outlet : T_MerchantType
    {
        public override List<KeyValuePair<string, int>> MerchantInventory => new List<KeyValuePair<string, int>>()
        {
            new KeyValuePair<string, int>( vItem.BananaPeel, 3),
            new KeyValuePair<string, int>( vItem.Beartrap, 4),
            new KeyValuePair<string, int>( vItem.CigaretteLighter, 2),
            new KeyValuePair<string, int>( vItem.LandMine, 4),
            new KeyValuePair<string, int>( vItem.OilContainer, 2),
            new KeyValuePair<string, int>( vItem.ParalyzerTrap, 4),
        };

        [RLSetup]
        public static void Setup()
        {
            PostProcess = RogueLibs.CreateCustomTrait<Home_Fortress_Outlet>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = String.Format("This character sells traps."),
                    
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DesignerName(typeof(Home_Fortress_Outlet)),
                    
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
