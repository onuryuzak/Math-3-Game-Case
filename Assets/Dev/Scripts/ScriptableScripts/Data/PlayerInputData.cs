using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameData/Channel/PlayerInputData", fileName = "PlayerInputData")]
public class PlayerInputData : ScriptableObject
{
    [MyBox.ReadOnly] public float Horizontal;
    [MyBox.ReadOnly] public float Vertical;
    [MyBox.ReadOnly] public bool Holding;

    [MyBox.ReadOnly] public bool Released;
    [MyBox.ReadOnly] public bool Tapped;

    public UnityEvent OnTapped;
    public UnityEvent OnReleased;
}