using UnityEngine;

namespace Crescive.Sounds
{
    [CreateAssetMenu(menuName = "GameData/Channel/SoundSystem", fileName = "SoundSystem")]
    public class SoundSystem : ScriptableObject
    {
        private const string SOUNDS_ACTIVE_KEY_PREF = "Sounds_Active";

        public bool SoundsActive
        {
            get => PlayerPrefs.GetInt(SOUNDS_ACTIVE_KEY_PREF, 1) == 1;
            set => PlayerPrefs.SetInt(SOUNDS_ACTIVE_KEY_PREF, value ? 1 : 0);
        }

        public void SetSoundsActive(bool active) => SoundsActive = active;
        public void ToggleSoundsActive() => SoundsActive = !SoundsActive;
    }
}