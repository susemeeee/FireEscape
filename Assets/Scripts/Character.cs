using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Camera cam;
    public float limitTime;
    public Text timer;
    public Text notice;
    private int escapeSuccess;
    private bool stop;

    void Start()
    {
        escapeSuccess = 0;
        stop = false;
    }

    void Update()
    {
        move();

        if(limitTime >= 0)
        {
            limitTime -= Time.deltaTime;
            timer.text = "남은 시간: " + Mathf.Round(limitTime) + "초";
        }
        else
        {
            timer.text = "";
            if(limitTime != -6000)
            {
                ending("탈출 실패: 시간 초과\n탈출은 3분 내에 이루어져야 합니다.", 2);
            }
            else
            {
                limitTime = -6000;
            }
        }
    }

    private void move()
    {
        Vector3 dir = cam.transform.localRotation * Vector3.forward;
        gameObject.transform.Translate(dir * 2.0f * Time.deltaTime);
    }

    public void ending(string msg, int escapeSuccess)
    {
        if((this.escapeSuccess) == 0)
        {
            this.escapeSuccess = escapeSuccess;
            notice.text = msg;
        }
    }
}
