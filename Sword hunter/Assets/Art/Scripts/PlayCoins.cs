using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCoins : MonoBehaviour
{
    private string KEY_COINS = "coins";
    Text m_pcoin;
    int coins;
    int pcoin;
    public bool isCoin = false;
    public int tcoin;
    // Start is called before the first frame update
    void Start()
    {
        pcoin = 0;
        m_pcoin = GetComponent<Text>();
        m_pcoin.text = pcoin.ToString();
        string c = PlayerPrefs.GetString(KEY_COINS);
        coins = int.Parse(c);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoin)
        {
            PCoins(tcoin);
        }
    }
    public void PCoins(int coin)
    {
        pcoin += coin;
        coins += coin;
        PlayerPrefs.SetString(KEY_COINS, coins.ToString());
        m_pcoin.text = pcoin.ToString();
        isCoin = false;
    }
}
