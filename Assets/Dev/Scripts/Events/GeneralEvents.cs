using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Base.Events
{
    public static partial class GameEvents
    {
        public static class GeneralEvents
        {
            public static Action OnEntryCompleted;
            public static Action OnGameInitializationStarted;
            public static Action OnGameInitializationCompleted;
        }
    }
}