using System.Collections.Generic;
using NaughtyAttributes;
using Sirenix.Utilities;
using UnityEngine;

namespace GameCore.Scripts.Interactables
{
    public class InteractableWithTag : BaseInteractable
    {
        [SerializeField] [Tag] private List<string> tags;
        protected override bool ValidateActor(GameObject g) => tags.IsNullOrEmpty() || tags.Contains(g.tag);
    }
}

