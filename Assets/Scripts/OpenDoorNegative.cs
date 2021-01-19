using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class OpenDoorNegative : MonoBehaviour
{
    public Image LoadingBar;
    private bool IsOn;
    private float barTime = 0.0f;
    private bool isOpen;

    void Start()
    {
        IsOn = false;
        isOpen = false;
        LoadingBar.fillAmount = 0;
    }


    void Update()
    {
        if (IsOn)
        {
            if (barTime <= 3.0f)
            {
                barTime += Time.deltaTime;
            }
            else
            {
                if (!isOpen)
                {
                    gameObject.transform.Rotate(new Vector3(0, -90, 0));
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                LoadingBar.fillAmount = barTime / 3.0f;
            }
        }

    }

    public void SetGazedAt(bool gazedAt)
    {
        IsOn = gazedAt;
        barTime = 0.0f;
        if (!gazedAt)
        {
            LoadingBar.fillAmount = 0;
        }
    }
}
