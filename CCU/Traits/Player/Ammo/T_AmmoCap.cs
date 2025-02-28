﻿using BepInEx.Logging;
using RogueLibsCore;

namespace CCU.Traits.Player.Ammo
{
    public abstract class T_AmmoCap : T_PlayerTrait
	{
		private static readonly ManualLogSource logger = CCULogger.GetLogger();
		public static GameController GC => GameController.gameController;

		public T_AmmoCap() : base() { }

        public override void OnAdded() 
		{
			foreach (InvItem invItem in Owner.inventory.InvItemList)
				RecalculateMaxAmmo(Owner, invItem, false);
		}
        public override void OnRemoved()
		{
			foreach (InvItem invItem in Owner.inventory.InvItemList)
				RecalculateMaxAmmo(Owner, invItem, false);
		}

        public abstract float AmmoCapMultiplier { get; }

		public static void RecalculateMaxAmmo(Agent agent, InvItem invItem, bool setInitCount)
		{
			if (invItem.itemType != "WeaponProjectile")
				return;

			float total = invItem.initCount;

			foreach (T_AmmoCap trait in agent.GetTraits<T_AmmoCap>())
				total *= trait.AmmoCapMultiplier;

			if (invItem.contents.Contains(vItem.AmmoCapacityMod))
				total *= 1.4f;

			invItem.maxAmmo = (int)total;

			if (setInitCount)
				invItem.invItemCount = invItem.maxAmmo;
		}

		public static void ResetMaxAmmoOnSpill(Agent agent, InvItem invItem)
        {
			float total = invItem.initCount;

			if (invItem.contents.Contains(vItem.AmmoCapacityMod))
				total *= 1.4f;

			if (invItem.maxAmmo > invItem.initCount)
				invItem.maxAmmo = (int)total;

			if (invItem.invItemCount > invItem.maxAmmo)
				invItem.invItemCount = invItem.maxAmmo;
        }
	}
}
