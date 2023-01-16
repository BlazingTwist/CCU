﻿using CCU.Localization;
using RogueLibsCore;

namespace CCU.Traits.Rel_Faction
{
    public class Cannibal_Aligned : T_Rel_Faction
    {
        public override int Faction => 0;
        public override Alignment FactionAlignment => throw new System.NotImplementedException();

        [RLSetup]
        public static void Setup()
        {
            PostProcess = RogueLibs.CreateCustomTrait<Cannibal_Aligned>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Agent is Aligned to Cannibals and anyone else with this trait.",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DesignerName(typeof(Cannibal_Aligned)),
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

        public override string GetRelationshipTo(Agent agent) =>
            agent.agentName == VanillaAgents.Cannibal ||
            agent.HasTrait<Cannibal_Aligned>()
                ? VRelationship.Aligned
                : null;
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
