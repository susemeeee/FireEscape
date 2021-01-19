using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        string msg = "탈출 성공";
        GameObject.FindGameObjectWithTag("CHARACTER").GetComponent<Character>().ending(msg, 1);
    }
}
