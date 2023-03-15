using System;

namespace Base.Events
{
    public static partial class GameEvents
    {
        public static class UIEvents
        {
            public static Action<MinionType> OnMinionMerge;
        }
    }
}