using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sound()
    {
        GameObject z = GameObject.FindGameObjectWithTag("Sound");
        if (z != null)
        {
            AudioSource sound = z.GetComponent<AudioSource>();
            if (sound != null)
            {
                sound.mute = false;
            }
        }
        GameObject f = GameObject.FindGameObjectWithTag("Player");
        if (f != null)
        {
            AudioSource psound = f.GetComponent<AudioSource>();
            if (psound != null)
            {
                psound.mute = false;
            }
        }
        GameObject w = GameObject.FindGameObjectWithTag("Win");
        if (w != null)
        {
            AudioSource wsound = w.GetComponent<AudioSource>();
            if (wsound != null)
            {
                wsound.mute = false;
            }
        }
    }
    public void Mute()
    {
        GameObject z = GameObject.FindGameObjectWithTag("Sound");
        if (z != null)
        {
            AudioSource sound = z.GetComponent<AudioSource>();
            if (sound != null)
            {
                sound.mute = true;
            }
        }
        GameObject f = GameObject.FindGameObjectWithTag("Player");
        if (f != null)
        {
            AudioSource psound = f.GetComponent<AudioSource>();
            if (psound != null)
            {
                psound.mute = true;
            }
        }
        GameObject w = GameObject.FindGameObjectWithTag("Win");
        if (w != null)
        {
            AudioSource wsound = w.GetComponent<AudioSource>();
            if (wsound != null)
            {
                wsound.mute = true;
            }
        }
    }
}
