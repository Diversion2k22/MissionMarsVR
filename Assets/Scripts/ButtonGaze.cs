using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGaze : MonoBehaviour
{
    private bool isLookedAt = false;
    public float timerDuration = 3f;
    private float lookTimer = 0f;
    [SerializeField]
    Image gazeTimer;
    GameObject temp;
    void Update()
    {
        if (isLookedAt)
        {
            lookTimer += Time.deltaTime;
            gazeTimer.fillAmount = lookTimer / timerDuration;

            if (lookTimer > timerDuration)
            {
                lookTimer = 0f;
                if(temp!=null) temp.GetComponent<Click>().SimulateClick();
            }
        }

        else
        {
            lookTimer = 0f;
            gazeTimer.fillAmount = 0f;
        }
    }
    public void SetGazedAt(bool gazedAt)
    {
        isLookedAt = gazedAt;
       
    }

    public void SetObject(GameObject g)
    {
        temp = g;
    }

    public void ResetGameObject()
    {
        temp = null;
    }
}
