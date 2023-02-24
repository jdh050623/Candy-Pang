using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] soundsList;
    // Start is called before the first frame update
    public void PlayRandomDestroyNoise()
    {
        soundsList[1].Play();
    }

    public void PlayButtonSound()
    {
        soundsList[0].Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
