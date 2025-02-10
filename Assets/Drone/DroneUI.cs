using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DroneUI : MonoBehaviour
{
    private Button exitButton;
    [SerializeField] TextMeshProUGUI veloocityTmpro;
    [SerializeField] TextMeshProUGUI wolrdPoseTmpro;

    // Start is called before the first frame update
    void Start()
    {
        exitButton = GameObject.Find("ExitButton")?.GetComponent<Button>();

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitApplication);
        }
    }

    // Update is called once per frame
    void Update()
    {
        veloocityTmpro.text = "Velocity: " + GetComponent<Rigidbody>().linearVelocity.ToString();
        wolrdPoseTmpro.text = "WorldPose: " + transform.position.ToString();
    }
    
    public void ExitApplication()
    {
        Debug.Log("Exiting the application..."); // For debugging
        Application.Quit(); // Closes the application (only works in build mode)
    }
}
