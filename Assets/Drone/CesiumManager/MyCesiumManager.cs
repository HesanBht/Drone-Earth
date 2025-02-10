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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (applyCordinatesButton != null)
            applyCordinatesButton.onClick.AddListener(ApplyCordinates);

        cesiumGeoreference = FindFirstObjectByType<CesiumGeoreference>();

    }
    // Update is called once per frame
    void Update()
    {

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
