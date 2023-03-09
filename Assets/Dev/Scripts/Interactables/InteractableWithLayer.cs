using UnityEngine;

namespace GameCore.Scripts.Interactables
{
    public class InteractableWithLayer : BaseInteractable
    {
        [SerializeField] private LayerMask layer;

        protected override bool ValidateActor(GameObject g)
        {
            var shifted = 1 << g.layer;
            return (layer & shifted) != 0;
        }
    }
}
