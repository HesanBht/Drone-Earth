using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerInputManager : MonoBehaviour
{
    [Header("Drone Ctonroll Keys")]
    [SerializeField] KeyCode upKey = KeyCode.W;
    [SerializeField] KeyCode downKey = KeyCode.S;
    [SerializeField] KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] KeyCode rightKey = KeyCode.RightArrow;
    [SerializeField] KeyCode forwardKey = KeyCode.UpArrow;
    [SerializeField] KeyCode backwardKey = KeyCode.DownArrow;
    [SerializeField] KeyCode rotateLeftKey = KeyCode.A;
    [SerializeField] KeyCode rotateRightKey = KeyCode.D;

    [Space]
    [SerializeField] bool AxisBasedControllKeys = false;
    [SerializeField] float AxisBasedControllKeysSensitivity = 1f;

    [Header("Debug, DountToch")]
    [SerializeField] Vector3 droneMovementInputVector = Vector3.zero;
    int targetXVector;
    int targetYVector;
    int targetZVector;

    float currentXVector;
    float currentYVector;
    float currentZVector;



    float droneRotationAxis = 0f;


    [Header("cameraControll")]
    [SerializeField] KeyCode switchCammeraKey = KeyCode.Z;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ReadDroneControllInputs();
    }

    void ReadDroneControllInputs()
    {
        if (Input.GetKey(upKey))
        {
            //   droneMovementInputVector = new Vector3(droneMovementInputVector.x, 1, droneMovementInputVector.z);
            targetYVector = 1;
        }
        else if (Input.GetKey(downKey))
        {
            //  droneMovementInputVector = new Vector3(droneMovementInputVector.x, -1, droneMovementInputVector.z);
            targetYVector = -1;
        }
        else
        {
            //  droneMovementInputVector = new Vector3(droneMovementInputVector.x, 0, droneMovementInputVector.z);
            targetYVector = 0;
        }



        if (Input.GetKey(forwardKey))
        {
            //  droneMovementInputVector = new Vector3(droneMovementInputVector.x, droneMovementInputVector.y, 1);
            targetZVector = 1;
        }
        else if (Input.GetKey(backwardKey))
        {
            // droneMovementInputVector = new Vector3(droneMovementInputVector.x, droneMovementInputVector.y, -1);
            targetZVector = -1;
        }
        else
        {
            // droneMovementInputVector = new Vector3(droneMovementInputVector.x, droneMovementInputVector.y, 0);
            targetZVector = 0;
        }



        if (Input.GetKey(leftKey))
        {
            // droneMovementInputVector = new Vector3(-1, droneMovementInputVector.y, droneMovementInputVector.z);
            targetXVector = -1;
        }
        else if (Input.GetKey(rightKey))
        {
            //  droneMovementInputVector = new Vector3(1, droneMovementInputVector.y, droneMovementInputVector.z);
            targetXVector = 1;
        }
        else
        {
            //   droneMovementInputVector = new Vector3(0, droneMovementInputVector.y, droneMovementInputVector.z);
            targetXVector = 0;
        }



        if (Input.GetKey(rotateLeftKey))
        {
            droneRotationAxis = -1;
        }
        else if (Input.GetKey(rotateRightKey))
        {
            droneRotationAxis = 1;
        }
        else
        {
            droneRotationAxis = 0;
        }

        calculateAxisBasis();

        droneMovementInputVector = new Vector3(currentXVector, currentYVector, currentZVector);
    }

    void calculateAxisBasis()
    {
        if (!AxisBasedControllKeys)
        {
            currentXVector = targetXVector;
            currentYVector = targetYVector;
            currentZVector = targetZVector;
            return;
        }

        currentXVector = Mathf.MoveTowards(currentXVector, targetXVector, AxisBasedControllKeysSensitivity * Time.deltaTime);
        currentYVector = Mathf.MoveTowards(currentYVector, targetYVector, AxisBasedControllKeysSensitivity * Time.deltaTime);
        currentZVector = Mathf.MoveTowards(currentZVector, targetZVector, AxisBasedControllKeysSensitivity * Time.deltaTime);


    }

    public Vector3 GetDroneMovementInputVector()
    {
        return droneMovementInputVector;
    }
    public float GetDroneRotationAxis()
    {
        return droneRotationAxis;
    }


    public KeyCode GetSwitchCameraKey()
    {
        return switchCammeraKey;
    }
}
