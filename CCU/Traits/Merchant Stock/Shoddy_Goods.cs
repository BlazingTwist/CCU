﻿using RogueLibsCore;
using System;

namespace CCU.Traits.Merchant_Stock
{
    public class Shoddy_Goods : T_MerchantStock
    {
        [RLSetup]
        public static void Setup()
        {
            PostProcess = RogueLibs.CreateCustomTrait<Shoddy_Goods>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = String.Format("This agent sells items at 2/3 durability."),
                    
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DesignerName(typeof(Shoddy_Goods)),
                    
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
        public override void OnAddItem(ref InvItem invItem)
        {
            if (DurabilityTypes.Contains(invItem.itemType))
                invItem.invItemCount = (int)Math.Max(0, (invItem.invItemCount * 2f / 3f));
        }
        public override void OnRemoved() { }
    }
}
