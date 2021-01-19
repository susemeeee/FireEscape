using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeElevator : MonoBehaviour
{
    public bool isGet;
    private float noticeTime = 0.0f;
    void Start()
    {
        isGet = false;
    }


    void Update()
    {
        if (isGet)
        {
            noticeTime += Time.deltaTime;
        }
        if (noticeTime >= 2.0f)
        {
            string msg = "탈출 실패: 엘리베이터 탑승\n화재 발생 시 엘리베이터를 타면 안됩니다.";
            GameObject.FindGameObjectWithTag("CHARACTER").GetComponent<Character>().ending(msg, 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGet && other.gameObject.tag == "CHARACTER")
        {
            GameObject.FindGameObjectWithTag("CHARACTER").GetComponent<Character>().notice.text = "엘리베이터 탑승";
            isGet = true;
        }
    }
}
