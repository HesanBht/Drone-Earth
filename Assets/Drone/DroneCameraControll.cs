using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class DroneCameraControll : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras = new List<GameObject>();

    PlayerInputManager playerInputManager;

  [SerializeField]  int currentCameraIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        AssingCurrentCameraIndex();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
    }

    void SwitchCamera()
    {
        if (!Input.GetKeyDown(playerInputManager.GetSwitchCameraKey()))
            return;

        currentCameraIndex++;
        if (currentCameraIndex == cameras.Count)
            currentCameraIndex = 0;

        foreach (var cam in cameras)
        {
            cam.SetActive(false);
        }
        cameras[currentCameraIndex].SetActive(true);

    }

    void AssingCurrentCameraIndex()
    {
        foreach (var cam in cameras)
        {
            if (cam.activeSelf)
            {
                currentCameraIndex = cameras.IndexOf(cam);
            }
        }
    }
}
