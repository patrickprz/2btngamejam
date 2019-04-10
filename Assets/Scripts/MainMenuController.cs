using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI HighScoreText;

    #region Events
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        HighScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString("N0");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("play");
            StartCoroutine(WaitToLoad());
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("exit");
            StartCoroutine(WaitToExit());
        }
    }
    #endregion

    #region Coroutines
    IEnumerator WaitToLoad()
    {
        AudioMenuController.Instance.PlayClickSound();
        yield return new WaitForSeconds(0.5f);
        Play();
    }

    IEnumerator WaitToExit()
    {
        AudioMenuController.Instance.PlayClickSound();
        yield return new WaitForSeconds(0.5f);
        Exit();
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
