using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
    public float timeLogo = 2.0f;
    float isTimeLogo;
    bool logo = true;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadSceneAsync(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (logo)
        {
            isTimeLogo += Time.deltaTime;
            if (isTimeLogo > timeLogo)
            {
                SceneManager.LoadSceneAsync(1);
                logo = false;
            }
        }
    }
}
