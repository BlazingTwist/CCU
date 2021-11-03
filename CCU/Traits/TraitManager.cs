﻿using BepInEx.Logging;
using CCU.Traits.Hire;
using CCU.Traits.TraitTrigger;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using CCU.Traits.Relationships;
using CCU.Traits.MapMarker;
using CCU.Traits.Spawn;
using System.IO;
using CCU.Traits.Passive;
using CCU.Traits.Active;
using CCU.Traits.Appearance.FacialHair;
using CCU.Traits.MerchantType;

namespace CCU.Traits
{
	public static class TraitManager
	{
		private static readonly ManualLogSource logger = CCULogger.GetLogger();
		public static GameController GC => GameController.gameController;

		public static List<Type> AllCCUTraitsGroup
		{
			get
			{
				List<Type> list = new List<Type>();

				list.AddRange(AppearanceTraitsGroup);

				list.AddRange(BehaviorActiveTraits);
				list.AddRange(BehaviorPassiveTraits);
				list.AddRange(BodyguardedTraits);
				list.AddRange(HireCostTraits);
				list.AddRange(HireTypeTraits);
				list.AddRange(InteractionTraits);
				list.AddRange(LoadoutTraits);
				list.AddRange(RelationshipTraits);
				list.AddRange(TraitTriggerTraits);
				list.AddRange(MerchantTypeTraits);

				return list;
			}
		}
		public static List<string> AllCCUTraitNamesGroup
		{
			get
			{
				return AllCCUTraitsGroup.ConvertAll(t => TraitInfo.Get(t).Name);
			}
		}
		public static List<Type> AppearanceTraitsGroup
		{
			get
			{
				List<Type> list = new List<Type>();

				list.AddRange(FacialHairTraits);

				return list;
			}
		}
		public static List<Type> InteractionTraitsGroup
		{
			get
			{
				List<Type> list = new List<Type>();

				list.AddRange(HireTypeTraits);
				list.AddRange(InteractionTraits);
				list.AddRange(MerchantTypeTraits);

				return list;
			}
		}

		public static List<Type> BehaviorActiveTraits = new List<Type>()
		{
			typeof(Behavior_EatCorpse),
			typeof(Behavior_GrabDrugs),
			typeof(Behavior_GrabMoney),
			typeof(Behavior_Pickpocket),
			typeof(Behavior_SuckBlood),
		};
		public static List<Type> BehaviorPassiveTraits = new List<Type>()
		{
			typeof(Behavior_ExplodeOnDeath),
			typeof(Behavior_Guilty),
		};
		public static List<Type> BodyguardedTraits = new List<Type>()
		{
			typeof(Bodyguarded_Pilot),
		};
		public static List<Type> BuyerTraits = new List<Type>()
		{
			typeof(Buyer_All),
			typeof(Buyer_MerchantType),
		};
		public static List<Type> FacialHairTraits = new List<Type>()
		{
			typeof(Beard),
			typeof(Mustache),
			typeof(MustacheCircus),
			typeof(MustacheRedneck),
			typeof(NoFacialHair),
		};
		public static List<Type> HireCostTraits = new List<Type>()
		{
			typeof(HireCost_Banana),
			typeof(HireCost_Less),
			typeof(HireCost_More),
		};
		public static List<Type> HireDurationTraits = new List<Type>()
		{
			typeof(HireDuration_Permanent),
			typeof(HireDuration_PermanentOnly),
		};
		public static List<Type> HireTypeTraits = new List<Type>()
		{
			typeof(Hire_Bodyguard),
			typeof(Hire_BreakIn),
			typeof(Hire_CauseRuckus),
			typeof(Hire_DisarmTrap),
			typeof(Hire_Hack),
			typeof(Hire_Pickpocket),
			typeof(Hire_Poison),
			typeof(Hire_Safecrack),
			typeof(Hire_Tamper),
		};
		public static List<Type> InteractionTraits = new List<Type>()
		{
			typeof(Interaction_Extortable),
			typeof(Buyer_All),
			typeof(Interaction_Moochable),
			typeof(Buyer_MerchantType), // TODO: Review this, may have special usage as it's not in Vendor list
		};
		public static List<Type> LoadoutTraits = new List<Type>()
		{

		};
		public static List<Type> MapMarkerTraits = new List<Type>()
		{
			typeof(MapMarker_Pilot),
		};
		public static List<Type> RelationshipTraits = new List<Type>()
		{
			typeof(AnnoyedAtSuspicious),
			typeof(Faction_1_Aligned),
			typeof(Faction_1_Hostile),
			typeof(Faction_2_Aligned),
			typeof(Faction_2_Hostile),
			typeof(Faction_3_Aligned),
			typeof(Faction_3_Hostile),
			typeof(Faction_4_Aligned),
			typeof(Faction_4_Hostile),
			typeof(HostileToCannibals),
			typeof(HostileToSoldiers),
			typeof(HostileToVampires),
			typeof(HostileToWerewolves),
		};
		public static List<Type> TraitTriggerTraits = new List<Type>()
		{
			typeof(TraitTrigger_CommonFolk),
			typeof(TraitTrigger_CoolCannibal),
			typeof(TraitTrigger_CopAccess),
			typeof(TraitTrigger_FamilyFriend),
			typeof(TraitTrigger_HonorableThief),
			typeof(TraitTrigger_Scumbag),
		};
		public static List<Type> MerchantTypeTraits = new List<Type>()
		{
			typeof(MerchantType_Armorer),
			typeof(MerchantType_Assassin),
			typeof(MerchantType_Banana),
			typeof(MerchantType_Barbarian),
			typeof(MerchantType_Bartender),
			typeof(MerchantType_BartenderDive),
			typeof(MerchantType_BartenderFancy),
			typeof(MerchantType_Blacksmith),
			typeof(MerchantType_Cannibal),
			typeof(MerchantType_ConsumerElectronics),
			typeof(MerchantType_Contraband),
			typeof(MerchantType_ConvenienceStore),
			typeof(MerchantType_CopStandard),
			typeof(MerchantType_CopSWAT),
			typeof(MerchantType_Demolitionist),
			typeof(MerchantType_DrugDealer),
			typeof(MerchantType_Firefighter),
			typeof(MerchantType_FireSale),
			typeof(MerchantType_Gunsmith),
			typeof(MerchantType_HardwareStore),
			typeof(MerchantType_HighTech),
			typeof(MerchantType_HomeFortressOutlet),
			typeof(MerchantType_Hypnotist),
			typeof(MerchantType_JunkDealer),
			typeof(MerchantType_McFuds),
			typeof(MerchantType_MedicalSupplier),
			typeof(MerchantType_MiningGear),
			typeof(MerchantType_MonkeMart),
			typeof(MerchantType_MovieTheater),
			typeof(MerchantType_Occultist),
			typeof(MerchantType_OutdoorOutfitter),
			typeof(MerchantType_PacifistProvisioner),
			typeof(MerchantType_PawnShop),
			typeof(MerchantType_PestControl),
			typeof(MerchantType_Pharmacy),
			typeof(MerchantType_ResistanceCommissary),
			typeof(MerchantType_RiotDepot),
			typeof(MerchantType_Scientist),
			typeof(MerchantType_Shopkeeper),
			typeof(MerchantType_SlaveShop),
			typeof(MerchantType_Soldier),
			typeof(MerchantType_SportingGoods),
			typeof(MerchantType_Teleportationist),
			typeof(MerchantType_Thief),
			typeof(MerchantType_ThiefMaster),
			typeof(MerchantType_ThrowceryStore),
			typeof(MerchantType_ToyStore),
			typeof(MerchantType_UpperCruster),
			typeof(MerchantType_Vampire),
			typeof(MerchantType_Villain),
		};

		public static Type GetOnlyTraitFromList(Agent agent, List<Type> traitList)
		{
			List<Type> matchingTraits = traitList.Where(trait => agent.HasTrait(trait)).ToList();

			if (matchingTraits.Count > 1)
			{
				throw new InvalidDataException($"Agent {agent.name} was expected to have one trait from list,"
						+ $"but has {matchingTraits.Count} : [{string.Join(", ", matchingTraits.Select(trait => trait.Name))}]");
			}
			if (matchingTraits.Count == 0)
			{
				throw new InvalidDataException($"Agent {agent.name} was expected to have one trait from list, but has none.");
			}

			// use this one if you expect exactly one match
			return matchingTraits.First();

			// use this one if you expect zero or 1 matches
			return matchingTraits.FirstOrDefault();
		}
		public static bool HasTraitFromList(Agent agent, List<Type> traitList) =>
			traitList.Any(p => agent.HasTrait(p));
		public static void LogTraitList(Agent agent)
		{
			logger.LogDebug("TRAIT LIST: " + agent.agentName);

			foreach (Trait trait in agent.statusEffects.TraitList)
				logger.LogDebug("\t" + trait.traitName);
		}
		internal static List<Trait> OnlyNonhiddenTraits(List<Trait> traitList) =>
			traitList
				.Where(trait => !(AllCCUTraitsGroup.ConvertAll(t => TraitInfo.Get(t).Name).Contains(trait.traitName)))
				.ToList();
	}
}
