using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


public class DroneControllerPro : MonoBehaviour
{
    PlayerInputManager playerInputManager;

    Rigidbody drone;


    Vector3 movementVectorInput = Vector3.zero;
    float rotationAxisInput = 0f;


    float levitationForce = 0;
    float _liftingForce = 0;

    [Space]
    [SerializeField] float maxLiftForce = 200f;
    [Space]
    [SerializeField] float stopDamping = 10f; // Damping for stopping ascent and decent
    [SerializeField] float hoverStabilizationSpeed = 5f; // Speed of stabilization during hovering

    [Space]
    [SerializeField] float maxMoveSpeed = 50f;
    [SerializeField] float rotationSpeed = 50f;

    [Space]
    [SerializeField] GameObject droneModelObject;
    [SerializeField] float maxTilt = 10f;
    [SerializeField] float tiltSpeed = 1f;
    float currentXTilt =0;
    float currentZTilt =0;

    // Start is called before the first frame update
    void Start()
    {
        drone = GetComponent<Rigidbody>();
        playerInputManager = GetComponent<PlayerInputManager>();
        
        levitationForce = drone.mass * -Physics.gravity.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetPlayerInputs();
        Flying();
        Movement();
        Tilting();
    }

    void Flying()
    {
        // float _liftingForce = 0;

        if (movementVectorInput.y == 0)
        {
            CalculateLevitationForce();
        }
        else
        {
            _liftingForce = levitationForce + (movementVectorInput.y * maxLiftForce);
        }


        drone.AddForce(Vector3.up * _liftingForce);

    }
    void OldCalculateLevitationForce()
    {
        
        if (drone.linearVelocity.y < -0.01)
        {
            _liftingForce += levitationForce;
        }
        else if (drone.linearVelocity.y > 0.01)
        {
            _liftingForce = 0;
        }
        else
        {
            _liftingForce = levitationForce;
        }

    }


    void CalculateLevitationForce()
    {
        if (drone.linearVelocity.y > 0.1f) // Drone is ascending
        {
            // Apply counter force to stop upward motion
            _liftingForce = -stopDamping * drone.linearVelocity.y + levitationForce;
        }
        else if (drone.linearVelocity.y < -0.1f) // Drone is descending
        {
            // Smoothly stabilize to hover
            _liftingForce = -stopDamping * drone.linearVelocity.y + levitationForce;
        }
        else
        {
            // Perfectly hover
            _liftingForce = Mathf.Lerp(_liftingForce, levitationForce, Time.deltaTime * hoverStabilizationSpeed);
        }
    }


    void Movement()
    {
        Vector3 transofrmedMovementVector = transform.TransformDirection(movementVectorInput.x, 0, movementVectorInput.z).normalized;

        drone.linearVelocity = (new Vector3(transofrmedMovementVector.x * maxMoveSpeed,
            drone.linearVelocity.y,
            transofrmedMovementVector.z * maxMoveSpeed));



        transform.Rotate(Vector3.up * rotationAxisInput * rotationSpeed * Time.deltaTime);



    }


    void Tilting()
    {
        currentXTilt = Mathf.MoveTowards(currentXTilt, movementVectorInput.z * maxTilt, Time.deltaTime * tiltSpeed);
        currentZTilt = Mathf.MoveTowards(currentZTilt, movementVectorInput.x * maxTilt, Time.deltaTime * tiltSpeed);

        droneModelObject.transform.localRotation =
            Quaternion.Euler(currentXTilt, droneModelObject.transform.rotation.y, -currentZTilt);
    }
    void GetPlayerInputs()
    {
        movementVectorInput = playerInputManager.GetDroneMovementInputVector();
        rotationAxisInput = playerInputManager.GetDroneRotationAxis();
    }

    public void SetMoveRotateSpeed(float _rotate, float _move)
    {
        maxMoveSpeed = _move;
        rotationSpeed = _rotate;
    }
    public float GetMS()
    {
        return maxMoveSpeed;
    }
    public float GetRS()
    {
        return rotationSpeed;
    }
}
