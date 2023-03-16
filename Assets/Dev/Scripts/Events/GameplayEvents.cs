using System;
using System.Collections.Generic;

namespace Base.Events
{
    public static partial class GameEvents
    {
        public static class GameplayEvents
        {
            public static Action OnGameEnd;
            public static Action OnCheckPanelsCondition;
            public static Action<CountPanel> OnFoundCountPanelForMerge;
        }
    }
}