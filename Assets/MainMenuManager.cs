using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
   [SerializeField] TMP_InputField apiInputField;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    void QuitGame()
    {
        Application.Quit();
    }

   public void OnApiInputFieldValueChange()
    {
        FindFirstObjectByType<CrossSceneInfoHolder>().api = apiInputField.text;
    }
}
