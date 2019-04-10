using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameController : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioGameController Instance;
    private AudioSource Source;
    public AudioClip Fall, FlipFlop;
    private float lastDecimal = 0;
    private bool fallPlayed = false;
    private bool flopPlayed = false;

    private void Awake(){
        Instance = this;
        Source = GetComponent<AudioSource>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int newDecimal = (int)(GameMasterController.Instance.TimeElapsed / 40f);
        if (newDecimal > lastDecimal)
        {
            lastDecimal = newDecimal;
            Source.pitch += 0.03f;
        }
    }

    public void PlayFall(){
        Source.loop = false;
        
        if (!fallPlayed){
            Source.clip = Fall;
            Source.Play();
            fallPlayed = true;
        }
    }

    public void PlayFlipFlop(){
        Source.loop = false;

        if (!flopPlayed){
            Source.clip = FlipFlop;
            Source.Play();
            flopPlayed = true;
        }
    }

}
