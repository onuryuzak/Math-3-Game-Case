
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Base.Events;
using Base.Management;

namespace Base.Core 
{
    public class GameCore : ManagerBase 
    {
        [SerializeField] private List<ManagerBase> InitManagerList;
        public static GameCore Instance;


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            StartCoroutine(InitGame());
            Application.targetFrameRate = 60;
        }
        private IEnumerator InitGame()
        {
            GameEvents.GeneralEvents.OnGameInitializationStarted?.Invoke();
            foreach (var item in InitManagerList)
            {
                yield return item.InitManager();
            }
            GameEvents.GeneralEvents.OnGameInitializationCompleted?.Invoke();
        }

        protected override IEnumerator InitManagerProgress()
        {
            yield break;
        }
    }



}
