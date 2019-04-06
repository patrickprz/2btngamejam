using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Events
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("play");
            Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("exit");
            Exit();
        }
    }
    #endregion

    #region Methods
    public void Play()
    {
        SceneManager.LoadScene("game");
    }

    public void Exit()
    {
        Application.Quit();
    }
    #endregion
}
