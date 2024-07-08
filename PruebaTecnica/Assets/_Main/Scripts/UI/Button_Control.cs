using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Control : MonoBehaviour
{
    [SerializeField] int GameScene = 1;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(GameScene);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
