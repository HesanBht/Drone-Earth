using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UISetting : MonoBehaviour
{
    [SerializeField] GameObject uiParent;
    [SerializeField] TextMeshProUGUI msValueText;
    [SerializeField] TextMeshProUGUI rsValueText;
    [SerializeField] Slider moveSpeedSlider;
    [SerializeField] Slider rotateSpeedSlider;

    DroneControllerPro droneControllerPro;
    float minMS =10;
    float minRS = 30;
    [SerializeField] float maxMs = 50;
    [SerializeField] float maxRS = 100;
    float msSliderPercentage , rsSliderPercentage;


    [SerializeField] Button quitButton;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        droneControllerPro = FindFirstObjectByType<DroneControllerPro>();
        PercentageCalculator();
        moveSpeedSlider.value = msSliderPercentage;
        rotateSpeedSlider.value = rsSliderPercentage;

        quitButton.onClick.AddListener(QuitToMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PercentageCalculator()
    {
        float currentMs = droneControllerPro.GetMS();
        float currentRs = droneControllerPro.GetRS();

        msSliderPercentage = (currentMs-minMS)/(maxMs-minMS);
        rsSliderPercentage = (currentRs-minRS)/(maxRS-minRS);
    }

    public void CalculateAndSetMsRs()
    {
        float ms;
        float rs;

        ms = (moveSpeedSlider.value * (maxMs-minMS))+minMS;
        rs = (rotateSpeedSlider.value * (maxRS-minRS))+minRS;

        msValueText.text = ms.ToString();
        rsValueText.text = rs.ToString();

        droneControllerPro.SetMoveRotateSpeed(rs,ms);
    }
    public void ToggleUi()
    {
        uiParent.SetActive(!uiParent.activeSelf);
    }

    void QuitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
