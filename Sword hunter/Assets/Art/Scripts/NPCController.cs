using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float displayTime = 10.0f;
    public GameObject dialogBox;
    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(true);
        timerDisplay = displayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }
}
