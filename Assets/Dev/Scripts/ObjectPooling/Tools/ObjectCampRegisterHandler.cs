using System.Collections;
using System.Collections.Generic;
using Base.Management;
using Base.Scriptables;
using UnityEngine;

namespace Base.ObjectPooling.Tools
{
    public class ObjectCampRegisterHandler : ManagerBase
    {
        [SerializeField] private List<PrefabContaierSO> PrefabContaierSOList; 
        [SerializeField] private List<GameSOBase> RegisterSOList;
        [SerializeField] private List<ManagerBase> RegisterManagerList;
        protected override IEnumerator InitManagerProgress()
        {
            Register();
            yield return new WaitForEndOfFrame();
        }

        private void Register()
        {
            foreach (var item in PrefabContaierSOList)
                foreach (var map in item.GetRegisterMaps())
                    ObjectCamp.RegisterPrefab(map);

            foreach (var item in RegisterSOList)
                ObjectCamp.RegisterScriptable(item);

            foreach (var item in RegisterManagerList)
                ObjectCamp.RegisterManager(item);
        }
    }
}

