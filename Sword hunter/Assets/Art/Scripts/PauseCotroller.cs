using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCotroller : MonoBehaviour
{
	private string KEY_DATA = "map";

	public GameObject resume;
    public GameObject menu;
	public GameObject sound;
	public GameObject mute;
	public GameObject bg;
	public GameObject fire;
	public bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void clickPause()
	{
		if (!isPause)
		{
			isPause = true;
			resume.SetActive(true);
			menu.SetActive(true);
			sound.SetActive(true);
			mute.SetActive(true);
			bg.SetActive(true);
			fire.SetActive(false);
		}
	}

	public void clickResume()
	{
		if (isPause)
		{
			isPause = false;
			resume.SetActive(false);
			menu.SetActive(false);
			sound.SetActive(false);
			mute.SetActive(false);
			bg.SetActive(false);
			fire.SetActive(true);
		}
	}

	public void clickMenu()
	{
		PlayerPrefs.SetString(KEY_DATA, "2");
		SceneManager.LoadSceneAsync(3);
	}
}
