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
    [HideInInspector]
    public float TimeElapsed = 0f;
    [SerializeField]
    private TextMeshProUGUI DeathScoreText;
    [SerializeField]
    private GameObject DeathPanel;
    private bool isCounting = true;

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
    }

    void Update()
    {
        if (isCounting)
        {
            TimeElapsed += Time.deltaTime;
            ScoreText.text = TimeElapsed.ToString("N1");
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
        float.TryParse(ScoreText.text, out float res);
        PlayerPrefs.SetFloat("score", res);
    }
}
