
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CrossSceneInfoHolder : MonoBehaviour
{
    public string api;

    private void Awake()
    {
        if (FindObjectsByType<CrossSceneInfoHolder>(FindObjectsSortMode.None).Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }


   public void SetApi(string _value)
    {
        api = _value;
    }
}
