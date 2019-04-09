using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenuController : MonoBehaviour
{
    public static AudioMenuController Instance;
    public AudioClip playAudio, ExitAudio;

    private void Awake(){
        Instance = this;
    }

    public void PlayButtonSound(){
        print("Play Song");
    }

    public void ExitButtonSound(){
        print("Exit Audio");
    }
}
