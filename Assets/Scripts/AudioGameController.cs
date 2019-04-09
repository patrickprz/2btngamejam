using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameController : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioGameController Instance;
    public AudioSource Music;
    private float lastDecimal = 0;

    private void Awake(){
        Instance = this;
        Music = GetComponent<AudioSource>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int newDecimal = (int)(GameMasterController.Instance.TimeElapsed / 15f);
        if (newDecimal > lastDecimal)
        {
            lastDecimal = newDecimal;
            Music.pitch += 0.03f;
        }
    }
}
