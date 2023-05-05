using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthShop : MonoBehaviour
{
    private string KEY_HEALTH = "health";
    Text m_health;
    // Start is called before the first frame update
    void Start()
    {
        m_health = GetComponent<Text>();
        m_health.text = "Health: " + PlayerPrefs.GetString(KEY_HEALTH);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
