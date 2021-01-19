﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuborness : MonoBehaviour
{
    public bool isGet;
    private float noticeTime = 0.0f;
    private bool timerEnd;

    void Start()
    {
        isGet = false;
        timerEnd = false;
    }


    void Update()
    {
        if (isGet)
        {
            noticeTime += Time.deltaTime;
        }
        if (noticeTime >= 2.0f && !timerEnd)
        {
            GameObject.FindGameObjectWithTag("CHARACTER").GetComponent<Character>().notice.text = "";
            timerEnd = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGet && other.gameObject.tag == "CHARACTER")
        {
            GameObject.FindGameObjectWithTag("CHARACTER").GetComponent<Character>().notice.text = "완강기 획득";
            isGet = true;

            GameObject.FindGameObjectWithTag("CHARACTER").GetComponent<DamageFire>().fireDamage = 1;
        }
    }
}
