using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    private string KEY_SWORD = "sword";
    int usword;
    private string KEY_ARMOR = "armor";
    int uarmor;
    private string KEY_USE1 = "use1";
    int buse1;
    private string KEY_USE2 = "use2";
    int buse2;
    private string KEY_USE3 = "use3";
    int buse3;
    private string KEY_USE4 = "use4";
    int buse4;
    private string KEY_USE5 = "use5";
    int buse5;
    private string KEY_USE6 = "use6";
    int buse6;

    private string KEY_COINS = "coins";
    int coin;
    private string KEY_PCOINS = "pcoins";

    private string KEY_HEALTH = "health";
    private string KEY_DAMAGE = "damage";
    public GameObject sword;
    public GameObject sword1;
    public GameObject sword2;
    public GameObject sword3;
    public GameObject armor;
    public GameObject armor1;
    public GameObject armor2;
    public GameObject armor3;
    public bool useSword = true;
    public bool useSword1 = false;
    public bool useSword2 = false;
    public bool useSword3 = false;
    public bool useArmor = true;
    public bool useArmor1 = false;
    public bool useArmor2 = false;
    public bool useArmor3 = false;
    int health = 100;
    int damage = 10;
    public int maxHealth;
    public int maxDamage;
    int damS1 = 10;
    int damS2 = 20;
    int damS3 = 30;
    int heaA1 = 100;
    int heaA2 = 200;
    int heaA3 = 300;

    public GameObject shop;
    public bool isShop = false;
    public GameObject buySword1;
    public GameObject buySword2;
    public GameObject buySword3;
    public GameObject buyArmor1;
    public GameObject buyArmor2;
    public GameObject buyArmor3;
    public GameObject KD;
    int cs1 = 100;
    int cs2 = 200;
    int cs3 = 300;
    int ca1 = 100;
    int ca2 = 200;
    int ca3 = 300;

    public GameObject use;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject use1;
    public GameObject use2;
    public GameObject use3;
    public GameObject use4;
    public GameObject use5;
    public GameObject use6;
    public bool buyUse1 = false;
    public bool buyUse2 = false;
    public bool buyUse3 = false;
    public bool buyUse4 = false;
    public bool buyUse5 = false;
    public bool buyUse6 = false;

    public GameObject HD;

    private string KEY_DATA = "map";
    // Start is called before the first frame update
    void Start()
    {
        string scoins = PlayerPrefs.GetString(KEY_COINS);
        coin = int.Parse(scoins);
        PlayerPrefs.GetString(KEY_PCOINS, "0");

        string s = PlayerPrefs.GetString(KEY_SWORD);
        usword = int.Parse(s);

        string a = PlayerPrefs.GetString(KEY_ARMOR);
        uarmor = int.Parse(a);

        string u1 = PlayerPrefs.GetString(KEY_USE1);
        buse1 = int.Parse(u1);

        string u2 = PlayerPrefs.GetString(KEY_USE2);
        buse2 = int.Parse(u2);

        string u3 = PlayerPrefs.GetString(KEY_USE3);
        buse3 = int.Parse(u3);

        string u4 = PlayerPrefs.GetString(KEY_USE4);
        buse4 = int.Parse(u4);

        string u5 = PlayerPrefs.GetString(KEY_USE5);
        buse5 = int.Parse(u5);

        string u6 = PlayerPrefs.GetString(KEY_USE6);
        buse6 = int.Parse(u6);

        if (buse1 == 1)
        {
            buyUse1 = true;
        }
        else buyUse1 = false;

        if (buse2 == 1)
        {
            buyUse2 = true;
        }
        else buyUse2 = false;

        if (buse3 == 1)
        {
            buyUse3 = true;
        }
        else buyUse3 = false;

        if (buse4 == 1)
        {
            buyUse4 = true;
        }
        else buyUse4 = false;

        if (buse5 == 1)
        {
            buyUse5 = true;
        }
        else buyUse5 = false;

        if (buse6 == 1)
        {
            buyUse6 = true;
        }
        else buyUse6 = false;

        switch (usword)
        {
            case 1:
                useSword1 = true;
                break;
            case 2:
                useSword2 = true;
                break;
            case 3:
                useSword3 = true;
                break;
            default:
                useSword = true;
                break;
        }

        switch (uarmor)
        {
            case 1:
                useArmor1 = true;
                break;
            case 2:
                useArmor2 = true;
                break;
            case 3:
                useArmor3 = true;
                break;
            default:
                useArmor = true;
                break;
        }

        if (useSword)
        {
            sword.SetActive(true);
            sword1.SetActive(false);
            sword2.SetActive(false);
            sword3.SetActive(false);
        }
        else if (useSword1)
        {
            sword.SetActive(false);
            sword1.SetActive(true);
            sword2.SetActive(false);
            sword3.SetActive(false);
        }
        else if (useSword2)
        {
            sword.SetActive(false);
            sword1.SetActive(false);
            sword2.SetActive(true);
            sword3.SetActive(false);
        }
        else if (useSword3)
        {
            sword.SetActive(false);
            sword1.SetActive(false);
            sword2.SetActive(false);
            sword3.SetActive(true);
        }
        if (useArmor)
        {
            armor.SetActive(true);
            armor1.SetActive(false);
            armor2.SetActive(false);
            armor3.SetActive(false);
        }
        else if (useArmor1)
        {
            armor.SetActive(false);
            armor1.SetActive(true);
            armor2.SetActive(false);
            armor3.SetActive(false);
        }
        else if (useArmor2)
        {
            armor.SetActive(false);
            armor1.SetActive(false);
            armor2.SetActive(true);
            armor3.SetActive(false);
        }
        else if (useArmor3)
        {
            armor.SetActive(false);
            armor1.SetActive(false);
            armor2.SetActive(false);
            armor3.SetActive(true);
        }
        shop.SetActive(false);
        buyArmor1.SetActive(false);
        buyArmor2.SetActive(false);
        buyArmor3.SetActive(false);
        buySword1.SetActive(false);
        buySword2.SetActive(false);
        buySword3.SetActive(false);
        KD.SetActive(false);

        use.SetActive(true);
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
        text6.SetActive(false);
        use1.SetActive(false);
        use2.SetActive(false);
        use3.SetActive(false);
        use4.SetActive(false);
        use5.SetActive(false);
        use6.SetActive(false);

        HD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickCity1()
    {
        PlayerPrefs.SetString(KEY_DATA, "4");
        SceneManager.LoadSceneAsync(3);
    }
    public void clickCity2()
    {
        PlayerPrefs.SetString(KEY_DATA, "5");
        SceneManager.LoadSceneAsync(3);
    }
    public void clickCity3()
    {
        PlayerPrefs.SetString(KEY_DATA, "6");
        SceneManager.LoadSceneAsync(3);
    }
    public void clickCity4()
    {
        PlayerPrefs.SetString(KEY_DATA, "7");
        SceneManager.LoadSceneAsync(3);
    }

    public void clickUseSword1()
    {
        if (!isShop)
        {
            if (buyUse1)
            {
                useSword1 = true;
                sword.SetActive(false);
                sword1.SetActive(true);
                sword2.SetActive(false);
                sword3.SetActive(false);
                maxDamage = damage + damS1;
                PlayerPrefs.SetString(KEY_DAMAGE, maxDamage.ToString());
                PlayerPrefs.SetString(KEY_SWORD, "1");
                SceneManager.LoadSceneAsync(2);
            }
        }
    }
    public void clickUseSword2()
    {
        if (!isShop)
        {
            if (buyUse2)
            {
                useSword2 = true;
                sword.SetActive(false);
                sword1.SetActive(false);
                sword2.SetActive(true);
                sword3.SetActive(false);
                maxDamage = damage + damS2;
                PlayerPrefs.SetString(KEY_DAMAGE, maxDamage.ToString());
                PlayerPrefs.SetString(KEY_SWORD, "2");
                SceneManager.LoadSceneAsync(2);
            }
        }
    }
    public void clickUseSword3()
    {
        if (!isShop)
        {
            if (buyUse3)
            {
                useSword3 = true;
                sword.SetActive(false);
                sword1.SetActive(false);
                sword2.SetActive(false);
                sword3.SetActive(true);
                maxDamage = damage + damS3;
                PlayerPrefs.SetString(KEY_DAMAGE, maxDamage.ToString());
                PlayerPrefs.SetString(KEY_SWORD, "3");
                SceneManager.LoadSceneAsync(2);
            }
        }
    }
    public void clickUseArmor1()
    {
        if (!isShop)
        {
            if (buyUse4)
            {
                useArmor1 = true;
                armor.SetActive(false);
                armor1.SetActive(true);
                armor2.SetActive(false);
                armor3.SetActive(false);
                maxHealth = health + heaA1;
                PlayerPrefs.SetString(KEY_HEALTH, maxHealth.ToString());
                PlayerPrefs.SetString(KEY_ARMOR, "1");
                SceneManager.LoadSceneAsync(2);
            }
        }
    }
    public void clickUseArmor2()
    {
        if (!isShop)
        {
            if (buyUse5)
            {
                useArmor2 = true;
                armor.SetActive(false);
                armor1.SetActive(false);
                armor2.SetActive(true);
                armor3.SetActive(false);
                maxHealth = health + heaA2;
                PlayerPrefs.SetString(KEY_HEALTH, maxHealth.ToString());
                PlayerPrefs.SetString(KEY_ARMOR, "2");
                SceneManager.LoadSceneAsync(2);
            }
        }
    }
    public void clickUseArmor3()
    {
        if (!isShop)
        {
            if (buyUse6)
            {
                useArmor3 = true;
                armor.SetActive(false);
                armor1.SetActive(false);
                armor2.SetActive(false);
                armor3.SetActive(true);
                maxHealth = health + heaA3;
                PlayerPrefs.SetString(KEY_HEALTH, maxHealth.ToString());
                PlayerPrefs.SetString(KEY_ARMOR, "3");
                SceneManager.LoadSceneAsync(2);
            }
        }
    }
    public void clickUse1()
    {
        if (!isShop)
        {
            text1.SetActive(true);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            if (buyUse1)
            {
                use1.SetActive(true);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(false);
            }
            else
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(false);
            }
        }
    }
    public void clickUse2()
    {
        if (!isShop)
        {
            text1.SetActive(false);
            text2.SetActive(true);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            if (buyUse2)
            {
                use1.SetActive(false);
                use2.SetActive(true);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(false);
            }
            else
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(false);
            }
        }
    }
    public void clickUse3()
    {
        if (!isShop)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(true);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            if (buyUse3)
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(true);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(false);
            }
            else
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(false);
            }
        }
    }
    public void clickUse4()
    {
        if (!isShop)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(true);
            text5.SetActive(false);
            text6.SetActive(false);
            if (buyUse4)
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(true);
                use5.SetActive(false);
                use6.SetActive(false);
            }
            else
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(false);
            }
        }
    }
    public void clickUse5()
    {
        if (!isShop)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(true);
            text6.SetActive(false);
            if (buyUse5)
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(true);
                use6.SetActive(false);
            }
            else
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(false);
            }
        }
    }
    public void clickUse6()
    {
        if (!isShop)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(true);
            if (buyUse6)
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(true);
            }
            else
            {
                use1.SetActive(false);
                use2.SetActive(false);
                use3.SetActive(false);
                use4.SetActive(false);
                use5.SetActive(false);
                use6.SetActive(false);
            }
        }
    }

    public void clickShop()
    {
        if (!isShop)
        {
            isShop = true;
            shop.SetActive(true);
            use.SetActive(false);
        }
    }
    public void clickShop1()
    {
        if (isShop)
        {
            buySword1.SetActive(true);
            buySword2.SetActive(false);
            buySword3.SetActive(false);
            buyArmor1.SetActive(false);
            buyArmor2.SetActive(false);
            buyArmor3.SetActive(false);
        }
    }
    public void clickShop2()
    {
        if (isShop)
        {
            buySword1.SetActive(false);
            buySword2.SetActive(true);
            buySword3.SetActive(false);
            buyArmor1.SetActive(false);
            buyArmor2.SetActive(false);
            buyArmor3.SetActive(false);
        }
    }
    public void clickShop3()
    {
        if (isShop)
        {
            buySword1.SetActive(false);
            buySword2.SetActive(false);
            buySword3.SetActive(true);
            buyArmor1.SetActive(false);
            buyArmor2.SetActive(false);
            buyArmor3.SetActive(false);
        }
    }
    public void clickShop4()
    {
        if (isShop)
        {
            buySword1.SetActive(false);
            buySword2.SetActive(false);
            buySword3.SetActive(false);
            buyArmor1.SetActive(true);
            buyArmor2.SetActive(false);
            buyArmor3.SetActive(false);
        }
    }
    public void clickShop5()
    {
        if (isShop)
        {
            buySword1.SetActive(false);
            buySword2.SetActive(false);
            buySword3.SetActive(false);
            buyArmor1.SetActive(false);
            buyArmor2.SetActive(true);
            buyArmor3.SetActive(false);
        }
    }
    public void clickShop6()
    {
        if (isShop)
        {
            buySword1.SetActive(false);
            buySword2.SetActive(false);
            buySword3.SetActive(false);
            buyArmor1.SetActive(false);
            buyArmor2.SetActive(false);
            buyArmor3.SetActive(true);
        }
    }

    public void clickBuy1()
    {
        if (isShop)
        {
            if (coin >= cs1 && !buyUse1)
            {
                coin -= cs1;
                buyUse1 = true;
                PlayerPrefs.SetString(KEY_USE1, "1");

                PlayerPrefs.SetString(KEY_COINS, coin.ToString());
                SceneManager.LoadSceneAsync(2);
                shop.SetActive(true);
            }
            else KD.SetActive(true);
        }
    }
    public void clickBuy2()
    {
        if (isShop)
        {
            if (coin >= cs2 && !buyUse2)
            {
                coin -= cs2;
                buyUse2 = true;
                PlayerPrefs.SetString(KEY_USE2, "1");

                PlayerPrefs.SetString(KEY_COINS, coin.ToString());
                SceneManager.LoadSceneAsync(2);
                shop.SetActive(true);
            }
            else KD.SetActive(true);
        }
    }
    public void clickBuy3()
    {
        if (isShop)
        {
            if (coin >= cs3 && !buyUse3)
            {
                coin -= cs3;
                buyUse3 = true;
                PlayerPrefs.SetString(KEY_USE3, "1");

                PlayerPrefs.SetString(KEY_COINS, coin.ToString());
                SceneManager.LoadSceneAsync(2);
                shop.SetActive(true);
            }
            else KD.SetActive(true);
        }
    }
    public void clickBuy4()
    {
        if (isShop)
        {
            if (coin >= ca1 && !buyUse4)
            {
                coin -= ca1;
                buyUse4 = true;
                PlayerPrefs.SetString(KEY_USE4, "1");

                PlayerPrefs.SetString(KEY_COINS, coin.ToString());
                SceneManager.LoadSceneAsync(2);
                shop.SetActive(true);
            }
            else KD.SetActive(true);
        }
    }
    public void clickBuy5()
    {
        if (isShop)
        {
            if (coin >= ca2 && !buyUse5)
            {
                coin -= ca2;
                buyUse5 = true;
                PlayerPrefs.SetString(KEY_USE5, "1");

                PlayerPrefs.SetString(KEY_COINS, coin.ToString());
                SceneManager.LoadSceneAsync(2);
                shop.SetActive(true);
            }
            else KD.SetActive(true);
        }
    }
    public void clickBuy6()
    {
        if (isShop)
        {
            if (coin >= ca3 && !buyUse6)
            {
                coin -= ca3;
                buyUse6 = true;
                PlayerPrefs.SetString(KEY_USE6, "1");

                PlayerPrefs.SetString(KEY_COINS, coin.ToString());
                SceneManager.LoadSceneAsync(2);
                shop.SetActive(true);
            }
            else KD.SetActive(true);
        }
    }

    public void clickQL()
    {
        if (isShop)
        {
            isShop = false;
            shop.SetActive(false);
            use.SetActive(true);
            SceneManager.LoadSceneAsync(2);
        }
    }

    public void clickKD()
    {
        if (isShop)
        {
            KD.SetActive(false);
        }
    }

    public void clickReset()
    {
        PlayerPrefs.SetString(KEY_SWORD, "0");
        PlayerPrefs.SetString(KEY_ARMOR, "0");
        PlayerPrefs.SetString(KEY_USE1, "0");
        PlayerPrefs.SetString(KEY_USE2, "0");
        PlayerPrefs.SetString(KEY_USE3, "0");
        PlayerPrefs.SetString(KEY_USE4, "0");
        PlayerPrefs.SetString(KEY_USE5, "0");
        PlayerPrefs.SetString(KEY_USE6, "0");
        PlayerPrefs.SetString(KEY_COINS, "500");
        PlayerPrefs.SetString(KEY_HEALTH, "100");
        PlayerPrefs.SetString(KEY_DAMAGE, "10");

        SceneManager.LoadSceneAsync(2);
    }

    public void clickHD()
    {
        HD.SetActive(true);
    }

    public void clickQL2()
    {
        HD.SetActive(false);
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
