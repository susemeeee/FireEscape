using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    public Image loadingBar;
    private bool isEscaped;
    private float escapeTime = -1.0f;

    void Start()
    {
        isEscaped = false;
    }


    void Update()
    {
        if (escapeTime >= 10.0f)
        {
            if (GameObject.FindGameObjectWithTag("STUBORNESS").GetComponent<Stuborness>().isGet && !isEscaped)
            {
                isEscaped = true;
                string msg = "탈출 성공";
                GameObject.FindGameObjectWithTag("CHARACTER").GetComponent<Character>().ending(msg, 1);
            }
            else if(!isEscaped)
            {
                string msg = "탈출 실패\n창문으로 뛰어내리면 안됩니다.";
                GameObject.FindGameObjectWithTag("CHARACTER").GetComponent<Character>().ending(msg, 2);
            }
            loadingBar.fillAmount = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CHARACTER")
        {
            escapeTime = 0.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (escapeTime >= 0)
        {
            escapeTime += Time.deltaTime;
            loadingBar.fillAmount = escapeTime / 10.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CHARACTER")
        {
            escapeTime = -1.0f;
            loadingBar.fillAmount = 0;
        }
    }
}
