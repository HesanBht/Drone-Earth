using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DroneUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI veloocityTmpro;
    [SerializeField] TextMeshProUGUI wolrdPoseTmpro;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        veloocityTmpro.text = "Velocity: " + GetComponent<Rigidbody>().linearVelocity.ToString();
        wolrdPoseTmpro.text = "WorldPose: " + transform.position.ToString();
    }
}
    
