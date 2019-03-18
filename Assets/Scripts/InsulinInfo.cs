using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InsulinInfo : MonoBehaviour
{
    public Text displayInsulin;
    public Money monn;
    public GameObject insulin;
    public int doses = 10;
    public bool needToTake = false;
    string sDoses;
    // Start is called before the first frame update
    void Start()
    {
        monn = GameObject.Find("computerdesk").GetComponent<Money>();
        insulin = GameObject.Find("Insulin");
        displayInsulin = insulin.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        sDoses = doses.ToString();
        displayInsulin.text = "Doses left: " + sDoses;
        if (needToTake) {
            displayInsulin.text = displayInsulin.text + "\n You need to take!";
        }
    }
    public void medicated()
    {
        //doses--;
        if (doses != 0)
        {

            doses -= 1;
            SetNeed(false);
        } else
        {
            if(monn.cash >= 500)
            {
                monn.cash -= 500;
                doses += 90;
            }
        }

    }
    public void SetNeed(bool set) {
        needToTake = set;
    }
}
