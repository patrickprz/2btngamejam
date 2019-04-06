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
