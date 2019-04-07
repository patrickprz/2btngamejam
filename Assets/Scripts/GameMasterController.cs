using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMasterController : MonoBehaviour
{
    public static GameMasterController Instance;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [HideInInspector]
    public float TimeElapsed;

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
        TimeElapsed += Time.deltaTime;
        ScoreText.text = TimeElapsed.ToString("N1");
    }
}
