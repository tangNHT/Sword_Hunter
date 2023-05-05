using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Slider slider;
    public float timeLoad = 5.0f;
    float isTimeLoad;
    AsyncOperation loadingOperation;
    // Start is called before the first frame update
    void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(2);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        /*isTimeLoad += Time.deltaTime;
        if (isTimeLoad < timeLoad && slider.value < 1.0f)
        {
            if (slider.value < 0.6f)
            {
                slider.value += 0.004f;
            }
            if (slider.value < 0.9f)
            {
                slider.value += 0.0025f;
            }
        }
        if (isTimeLoad > timeLoad)
        {
            slider.value = 1.0f;

        }*/
    }
}
