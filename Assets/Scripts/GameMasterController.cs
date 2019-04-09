using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMasterController : MonoBehaviour
{
    public static GameMasterController Instance;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private TextMeshProUGUI HighScoreText;
    [HideInInspector]
    public float TimeElapsed = 0f;
    [SerializeField]
    private TextMeshProUGUI DeathScoreText;
    [SerializeField]
    private GameObject DeathPanel;
    private bool isCounting = true;
    [SerializeField]
    private GameObject StartTip;

    private void Awake()
    {
        Instance = this;
    }
    public float GetScore()
    {
        float.TryParse(ScoreText.text, out float result);
        return result;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ScoreText.text = "0";
        StartTip.SetActive(true);
        StartCoroutine(ShowStartTip());
    }

    void Update()
    {
        if (isCounting)
        {
            TimeElapsed += Time.deltaTime;
            ScoreText.text = (TimeElapsed * 6).ToString("N0");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SceneManager.LoadScene("game");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                SceneManager.LoadScene("mainMenu");
            }
        }
    }

    public void StopCounter()
    {
        isCounting = false;
    }
    public void ShowDeathPanel()
    {
        DeathPanel.SetActive(true);
        DeathScoreText.text = ScoreText.text;

        int highScore = PlayerPrefs.GetInt("highscore", 0);
        HighScoreText.text = highScore.ToString("N0");
        int.TryParse(DeathScoreText.text, out int score);
        Debug.Log("high: " + highScore + "score: " + score);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            HighScoreText.text = score.ToString("N0");
        }
    }
    IEnumerator ShowStartTip()
    {
        Time.timeScale = 0.1f;
        float pauseEndTime = Time.realtimeSinceStartup + 2.5f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        StartTip.SetActive(false);
    }
}
