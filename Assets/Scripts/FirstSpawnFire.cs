using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FirstSpawnFire : MonoBehaviour
{
    private System.Random r = new System.Random();
    public GameObject obj;

    void Start()
    {
        int x = r.Next(0, 10) - 5;
        int y = r.Next(0, 13);
        int z = r.Next(0, 24) - 8;

        while(!isCorrectPosition(x, y, z))
        {
            x = r.Next(0, 10) - 5;
            y = r.Next(0, 13);
            z = r.Next(0, 24) - 8;
        }

        Instantiate(obj, new Vector3(x, y, z), Quaternion.identity);
    }


    void Update()
    {
        
    }

    private bool isCorrectPosition(float x, float y, float z)
    {
        if ((z >= -8 && z <= 1) && (y >= 0 && y <= 8))
        {
            return false;
        }
        if ((z >= 2 && z <= 9) && (x >= -5 && x <= 0) && (y >= 0 && y <= 8))
        {
            return false;
        }
        if ((z >= 2 && z <= 15) && (x == 4))
        {
            return false;
        }
        if ((z >= 10 && z <= 15) && (x >= -5 && x <= -2))
        {
            return false;
        }

        return true;
    }
}
