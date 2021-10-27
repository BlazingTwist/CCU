﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using RogueLibsCore;

namespace CCU.Mutators
{
	class FloralerFlora
	{
		[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new MutatorUnlock(CMutators.FloralerFlora, true))
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = CMutators.FloralerFlora,
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = "Spawns leaves around all plants.",
				});
		}
	}
}
