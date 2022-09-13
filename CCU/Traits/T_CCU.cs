﻿using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCU.Traits
{
    public abstract class T_CCU : CustomTrait
    {
        public static TraitBuilder PostProcess
        {
            // This is applied after each trait is created. I don't fully get how it works, but see where PP's value is assigned.
            set
            {
                value.Unlock.Unlock.cantLose = true;
                value.Unlock.Unlock.cantSwap = true;
                value.Unlock.Unlock.upgrade = null;
            }
        }

        // Remove all CCU traits that aren't Player traits
        public static List<Trait> DisplayableTraits(List<Trait> vanilla) =>
            vanilla.Where(t => IsTraitDisplayable(t)).ToList();

        public static bool IsTraitDisplayable(Trait trait) =>
            trait?.GetHook<T_CCU>() is null ||
            !(trait?.GetHook<T_PlayerTrait>() is null);

        public string TextName => 
            DesignerName(GetType());

        public static string DesignerName(Type type, string custom = null) =>
            "[CCU] " + 
            (type.Namespace).Split('.')[2].Replace('_', ' ') + 
            " - " +
            (custom ?? (type.Name).Replace('_', ' '));

        public static string LongishDocumentationName(Type type) =>
            (type.Namespace).Split('.')[2].Replace('_', ' ') +
            " - " +
            (type.Name).Replace('_', ' ');

        public static string PlayerName(Type type) =>
            (type.Name).Replace('_', ' ');
    }
}