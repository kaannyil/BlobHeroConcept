using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController instance;

    public AudioSource squishAudio, BossDyingAudio;
    private void Awake()
    {
        instance = this;
    }
}
