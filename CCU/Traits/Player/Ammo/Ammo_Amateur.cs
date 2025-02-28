﻿using RogueLibsCore;

namespace CCU.Traits.Player.Ammo
{
    internal class Ammo_Amateur : T_AmmoCap
    {
        public override float AmmoCapMultiplier => 1.4f;

        [RLSetup]
		public static void Setup()
		{
			PostProcess = RogueLibs.CreateCustomTrait<Ammo_Amateur>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Ammo capacity increased by 40%.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = PlayerName(typeof(Ammo_Amateur))
				})
				.WithUnlock(new TraitUnlock_CCU
				{
					Cancellations = { nameof(Ammo_Artiste), nameof(Ammo_Auteur) },
					CharacterCreationCost = 3,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsPlayerTrait = true,
					UnlockCost = 5,
					Upgrade = nameof(Ammo_Artiste),
				});
		}
	}
}