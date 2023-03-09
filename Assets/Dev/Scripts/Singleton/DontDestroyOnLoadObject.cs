using UnityEngine;


/// <summary>
/// Add it to the game object that you want it to be not destroyed on scene loads.
/// Generally used as parent. That's why make it parentless. 
/// </summary>
public class DontDestroyOnLoadObject : MonoBehaviour
{
    private void Awake()
    {
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }
}