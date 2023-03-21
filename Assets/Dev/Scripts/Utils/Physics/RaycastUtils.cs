using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCore.Scripts.PhysicsHelper
{
    public static class RaycastUtils
    {
        public static bool IsPointerOverUI()
        {
            var raycastResults = new List<RaycastResult>();
            var pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            return raycastResults.Any(result => result.isValid);
        }
    }
}