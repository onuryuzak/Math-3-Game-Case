using Base.Core.LevelSystem;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LevelTextTMP : MonoBehaviour
{
    [SerializeField] private LevelSystem _levelSystem;

    private void Start() => GetComponent<TextMeshProUGUI>().text =
        $"LV <#cccccc><size=140%>{_levelSystem.CurrentLevelNumber}";
}