using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAudio : MonoBehaviour
{
    AudioSource wr;
    // Start is called before the first frame update
    void Start()
    {
        wr = GetComponent<AudioSource>();
    }

    public void PlayWrapper()
    {
        wr.Play();
    }
}
