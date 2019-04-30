using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    public Image imgGaze;
    const float nSecond = 2f;

    float timer = 0;
    bool entered = false;

    public void PointerEnter()
    {
        entered = true;
    }

    public void PointerExit()
    {
        entered = false;
        timer = 0;
        imgGaze.fillAmount = 1;
    }

    void Update()
    {
        //If pointer is pointing on the object, start the timer
        if (entered)
        {
            //Increment timer
            timer += Time.deltaTime;
            imgGaze.fillAmount = 1 - (timer / nSecond);

            //Load scene if counter has reached the nSecond
            if (timer > nSecond)
            {
                SceneManager.LoadScene("Main");
            }
        }
        else
        {
            //Reset timer when it's no longer pointing
            timer = 0;
        }
    }
}