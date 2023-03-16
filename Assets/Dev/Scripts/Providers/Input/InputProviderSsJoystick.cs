using GameCore.Scripts.PhysicsHelper;
using UnityEngine;

namespace GameCore.Scripts.InputProvider
{
    public class InputProviderSsJoystick : MonoBehaviour
    {
        [SerializeField] private ScreenSpaceJoytick joystick;
        [SerializeField] private PlayerInputData playerInputData;

        private void Update()
        {
            var tapped = Input.GetMouseButtonDown(0);
            var released = Input.GetMouseButtonUp(0);
            if (tapped)
                playerInputData.OnTapped?.Invoke();

            if (released)
                playerInputData.OnReleased?.Invoke();

            playerInputData.Tapped = tapped;
            playerInputData.Released = released;

            playerInputData.Holding = Input.GetMouseButton(0);
            playerInputData.Horizontal = joystick.Horizontal;
            playerInputData.Vertical = joystick.Vertical;
        }
    }
}