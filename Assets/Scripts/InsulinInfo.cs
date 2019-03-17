using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InsulinInfo : MonoBehaviour
{
    public Text displayInsulin;
    public GameObject insulin;
    public int doses = 28;
    string sDoses;
    // Start is called before the first frame update
    void Start()
    {
        insulin = GameObject.Find("Insulin");
        displayInsulin = insulin.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        sDoses = doses.ToString();
        displayInsulin.text = "Doses left: " + sDoses;
    }
    void medicated()
    {
        if (doses != 0)
        {
            doses -= 1;
        }
    }
}
