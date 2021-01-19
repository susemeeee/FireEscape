using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFire : MonoBehaviour
{
    public Slider hp;
    public int fireDamage = 2;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {    
        if(other.gameObject.tag == "FIRE")
        {
            damage();
        }
    }

    public void damage()
    {
        if (hp.value > 0)
        {
            hp.value -= fireDamage;
            if(hp.value <= 0)
            {
                string msg = "탈출 실패: 화염 및 연기 노출";
                GameObject.FindGameObjectWithTag("CHARACTER").GetComponent<Character>().ending(msg, 2);
            }
        }
    }
}
