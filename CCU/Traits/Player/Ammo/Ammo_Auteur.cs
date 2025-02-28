﻿using RogueLibsCore;

namespace CCU.Traits.Player.Ammo
{
    internal class Ammo_Auteur : T_AmmoCap
    {
		public override float AmmoCapMultiplier => 2.2f;

		[RLSetup]
		public static void Setup()
		{
			PostProcess = RogueLibs.CreateCustomTrait<Ammo_Auteur>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Ammo capacity increased by 120%.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = PlayerName(typeof(Ammo_Auteur))
				})
				.WithUnlock(new TraitUnlock_CCU
				{
					Cancellations = { 
						nameof(Ammo_Amateur), 
						nameof(Ammo_Artiste) 
					},
					CharacterCreationCost = 7,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsPlayerTrait = true,
					UnlockCost = 5,
				});
		}
	}
}