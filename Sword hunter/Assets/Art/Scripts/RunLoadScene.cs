using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunLoadScene : MonoBehaviour
{
    public Slider slider;
    public float timeRunLoad = 2.0f;
    float isTimeRunLoad;
    AsyncOperation loadingOperation;

    private string KEY_DATA = "map";
    int map;
    /*private string KEY_SWORD = "sword";
    int sword;
    private string KEY_ARMOR = "armor";
    int armor;*/

    // Start is called before the first frame update
    void Start()
    {
        string m = PlayerPrefs.GetString(KEY_DATA);
        map = int.Parse(m);

        /*string s = PlayerPrefs.GetString(KEY_SWORD);
        sword = int.Parse(s);

        string a = PlayerPrefs.GetString(KEY_ARMOR);
        armor = int.Parse(a);

*/
        loadingOperation = SceneManager.LoadSceneAsync(map);
        //slider.value = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        /*isTimeRunLoad += Time.deltaTime;
        if (isTimeRunLoad < timeRunLoad && slider.value < 1.0f)
        {
            if (slider.value < 0.6f)
            {
                slider.value += 0.0057f;
            }
            else if (slider.value < 0.9f)
            {
                slider.value += 0.0045f;
            }
        }
        if(isTimeRunLoad >= timeRunLoad)
        {
            slider.value = 1.0f;
        }*/
    }
}
