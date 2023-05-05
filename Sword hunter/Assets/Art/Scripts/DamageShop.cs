using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageShop : MonoBehaviour
{
    private string KEY_DAMAGE = "damage";
    Text m_damage;
    // Start is called before the first frame update
    void Start()
    {
        m_damage = GetComponent<Text>();
        m_damage.text = "Damage: " + PlayerPrefs.GetString(KEY_DAMAGE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
