using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    bool isSpreaded;
    float spreadTime = 5.0f;
    float time = 0.0f;
    public GameObject obj;

    void Start()
    {
        isSpreaded = false;   
    }

    void Update()
    {
        if(!isSpreaded && (time >= spreadTime))
        {
            Vector3 pos = gameObject.transform.position;
            if(pos.x > -5)
            {
                if(isCorrectPosition(pos.x - 1, pos.y, pos.z))
                {
                    Instantiate(obj, new Vector3(pos.x - 1, pos.y, pos.z), Quaternion.identity);
                }
            }
            if(pos.x < 4)
            {
                if (isCorrectPosition(pos.x + 1, pos.y, pos.z))
                {
                    Instantiate(obj, new Vector3(pos.x + 1, pos.y, pos.z), Quaternion.identity);
                }
            }
            if(pos.y > 0)
            {
                if (isCorrectPosition(pos.x, pos.y - 1, pos.z))
                {
                    Instantiate(obj, new Vector3(pos.x, pos.y - 1, pos.z), Quaternion.identity);
                }
            }
            if(pos.y < 12)
            {
                if (isCorrectPosition(pos.x, pos.y + 1, pos.z))
                {
                    Instantiate(obj, new Vector3(pos.x, pos.y + 1, pos.z), Quaternion.identity);
                }
            }
            if(pos.z > -8)
            {
                if (isCorrectPosition(pos.x, pos.y, pos.z - 1))
                {
                    Instantiate(obj, new Vector3(pos.x, pos.y, pos.z - 1), Quaternion.identity);
                }
            }
            if(pos.z < 15)
            {
                if (isCorrectPosition(pos.x, pos.y, pos.z + 1))
                {
                    Instantiate(obj, new Vector3(pos.x, pos.y, pos.z + 1), Quaternion.identity);
                }
            }

            isSpreaded = true;
        }
        else if(!isSpreaded)
        {
            time += Time.deltaTime;
        }
    }

    private bool isCorrectPosition(float x, float y, float z)
    {
        if((z >= -8 && z <= 1) && (y >= 0 && y <= 8))
        {
            return false;
        }
        if((z >= 2 && z <= 9) && (x >= -5 && x <= 0) && (y >= 0 && y <= 8))
        {
            return false;
        }
        if((z >= 2 && z <= 15) && (x == 4))
        {
            return false;
        }
        if((z >= 10 && z <= 15) && (x >= -5 && x <= -2))
        {
            return false;
        }
        GameObject[] fires = GameObject.FindGameObjectsWithTag("FIRE");
        
        foreach(GameObject fire in fires)
        {
            float fireX = fire.transform.position.x;
            float fireY = fire.transform.position.y;
            float fireZ = fire.transform.position.z;

            if((x == fireX) && (y == fireY) && (z == fireZ))
            {
                return false;
            }
        }

        return true;
    }
}
