using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using System.Reflection;
using Base.Events;


[RequireComponent(typeof(UnityEngine.UI.Button))]
public class UIButtonAction : MonoBehaviour
{
    private MethodInfo method;
    FieldInfo info = default;

    private static string[] FriendlyTextureSizes
    {
        get
        {
            var properties = typeof(ButtonEvents)
                .GetFields(BindingFlags.Public | BindingFlags.Static).ToList();
            return properties.ConvertAll(x => x.Name).ToArray();
        }
    }

    [ValueDropdown("FriendlyTextureSizes")]
    public string ID = "Default";

    private UnityEngine.UI.Button button;

    private void Awake()
    {
        if (ID == "Default") return;
        TryGetComponent(out button);

        info = typeof(ButtonEvents)
            .GetField(ID, BindingFlags.Public | BindingFlags.Static);

        if (info != null)
        {
            button.onClick.AddListener(() =>
            {
                object yourField = info.GetValue(null);
                ButtonEvents.AnyButtonClicked?.Invoke();
                if (yourField == null) return;
                method = yourField.GetType().GetMethod("Invoke");
                method.Invoke(yourField, null);
            });
        }
    }
}