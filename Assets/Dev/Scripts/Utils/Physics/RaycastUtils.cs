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

        public static bool Raycast(out RaycastHit raycastHit, Ray ray, LayerMask layerMask,
            float maxDistance = float.MaxValue)
        {
            var hit = Physics.Raycast(ray, out var hitInfo, maxDistance, layerMask.value);
            raycastHit = hitInfo;
            return hit;
        }

        public static bool RaycastFromMousePosition(out RaycastHit raycastHit, LayerMask layerMask,
            Camera camera = null,
            float maxDistance = float.MaxValue)
        {
            if (camera == null)
                camera = Camera.main;
            var hit = Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition),
                out var hitInfo, maxDistance, layerMask.value);
            raycastHit = hitInfo;
            return hit;
        }

        public static bool OverlapSphereFromMousePosition(float radius,
            out RaycastHit[] raycastHits, LayerMask layerMask, Camera camera = null,
            float maxDistance = float.MaxValue)
        {
            if (camera == null)
                camera = Camera.main;

            var ray = camera.ScreenPointToRay(Input.mousePosition);
            raycastHits = Physics.SphereCastAll(ray, radius, maxDistance, layerMask);
            return raycastHits.Length > 0;
        }
    }
}