using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    private string KEY_DATA = "map";
    public int map;

    public GameObject win;
    public GameObject zbmboss;

    public int zom;

    public AudioClip winSound;
    AudioSource audioSource;
    bool isSound = false;
    // Start is called before the first frame update
    void Start()
    {
        string s = PlayerPrefs.GetString(KEY_DATA);
        map = int.Parse(s);
        win.SetActive(false);
        zbmboss.SetActive(false);
        zom = 0;

        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (map == 4)
        {
            if (zom == 4)
            {
                zbmboss.SetActive(true);
            }
            if (zom == 5)
            {
                Win();
            }
        }
        else if (map == 6)
        {
            if (zom == 7)
            {
                zbmboss.SetActive(true);
            }
            if (zom == 8)
            {
                Win();
            }
        }
        else if (map == 7)
        {
            if (zom == 7)
            {
                zbmboss.SetActive(true);
            }
            if (zom == 9)
            {
                Win();
            }
        }

        /*GameObject z = GameObject.FindGameObjectWithTag("Enemy");
        if (z != null)
        {
            WildController wild = z.GetComponent<WildController>();
            if (wild != null)
            {
                if (wild.isDead)
                {
                    zom += 1;
                }
            }
            WildNMController wildnm = z.GetComponent<WildNMController>();
            if (wildnm != null)
            {
                if (wildnm.isDead)
                {
                    zom += 1;
                }
            }
            ZombeGirlController zbg = z.GetComponent<ZombeGirlController>();
            if (zbg != null)
            {
                if (zbg.isDead)
                {
                    zom += 1;

                }
            }
            ZombeManController zbm = z.GetComponent<ZombeManController>();
            if (zbm != null)
            {
                if (zbm.isDead)
                {
                    zom += 1;
                }
            }
            ZombeGirlNMController zbgnm = z.GetComponent<ZombeGirlNMController>();
            if (zbgnm != null)
            {
                if (zbgnm.isDead)
                {
                    zom += 1;
                }
            }
            ZombeManNMController zbmnm = z.GetComponent<ZombeManNMController>();
            if (zbmnm != null)
            {
                if (zbmnm.isDead)
                {
                    zom += 1;
                }
            }
            ZombeManBossController zbmboss = z.GetComponent<ZombeManBossController>();
            if (zbmboss != null)
            {
                if (zbmboss.isDead)
                {
                    Win();
                }
            }
        }*/
    }
    void Win()
    {
        win.SetActive(true);
        
        GameObject ssound = GameObject.FindGameObjectWithTag("Sound");
        if (ssound != null)
        {
            AudioSource sound = ssound.GetComponent<AudioSource>();
            if (sound != null)
            {
                if (!sound.mute)
                {
                    isSound = true;
                }
                sound.mute = true;
            }
        }
        GameObject z = GameObject.FindGameObjectWithTag("Player");
        if (z != null)
        {
            FireController plr = z.GetComponent<FireController>();
            if (plr != null)
            {
                plr.isWin = true;
                plr.isDead = false;
            }
            AudioSource psound = z.GetComponent<AudioSource>();
            if (psound != null)
            {
                if (!psound.mute)
                {
                    isSound = true;
                }
                psound.mute = true;
            }
        }
    }
    public void clickWin()
    {
        if (isSound)
        {
            GameObject ssound = GameObject.FindGameObjectWithTag("Sound");
            if (ssound != null)
            {
                AudioSource sound = ssound.GetComponent<AudioSource>();
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
        }
        SceneManager.LoadSceneAsync(2);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
