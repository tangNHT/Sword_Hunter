using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    private string KEY_COINS = "coins";
    Text m_coin;
    // Start is called before the first frame update
    void Start()
    {
        m_coin = GetComponent<Text>();
        m_coin.text = PlayerPrefs.GetString(KEY_COINS);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
