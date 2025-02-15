using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CesiumForUnity;
using System;

public class MyCesiumManager : MonoBehaviour
{
    [SerializeField] CesiumGeoreference cesiumGeoreference;

    [SerializeField] TMP_InputField latitudeInput;
    [SerializeField] TMP_InputField longitudeInput;
    [SerializeField] TMP_InputField heightInput;
    [SerializeField] Button applyCordinatesButton;


    [Space(30)]
    [Header("DO NOT TOUCH VALUES")]
    [SerializeField] double latitude;
    [SerializeField] double longitude;
    [SerializeField] double height;



    [Space(30)]
    [SerializeField] string api = "";
    [SerializeField] CesiumIonServer cesiumIonServer;
    [SerializeField] Cesium3DTileset cesium3DTileset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (applyCordinatesButton != null)
            applyCordinatesButton.onClick.AddListener(ApplyCordinates);


        cesiumGeoreference = FindFirstObjectByType<CesiumGeoreference>();
        cesium3DTileset = FindFirstObjectByType<Cesium3DTileset>();

        ApiSetting();

    }
    // Update is called once per frame
    void Update()
    {

    }

    void ApiSetting()
    {
        if (FindFirstObjectByType<CrossSceneInfoHolder>() != null)
            api = FindFirstObjectByType<CrossSceneInfoHolder>().api;

        cesiumIonServer.defaultIonAccessToken = api;
        cesium3DTileset.url = "https://tile.googleapis.com/v1/3dtiles/root.json?key=" + api;
    }


    void ApplyCordinates()
    {
        bool a = false;
        bool b = false;
        bool c = false;

        if (double.TryParse(latitudeInput.text, out double _Latitude))
        {
            latitude = _Latitude;
            a = true;
        }
        if (double.TryParse(longitudeInput.text, out double _Longitude))
        {
            longitude = _Longitude;
            b = true;
        }
        if (double.TryParse(heightInput.text, out double _Height))
        {
            height = _Height;
            c = true;
        }


        if (a && b && c)
        {
            cesiumGeoreference.latitude = latitude;
            cesiumGeoreference.longitude = longitude;
            cesiumGeoreference.height = height;
        }
        else
        {
            Debug.Log("Check Input Fields and Enter again");
        }
    }

}
