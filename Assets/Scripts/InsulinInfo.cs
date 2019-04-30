using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityStandardAssets.ImageEffects;


public class InsulinInfo : MonoBehaviour
{
    public Text displayInsulin;
    //public Money monn;
    public GameObject insulin;
    //public int doses = 10;
    string sDoses;
    public SoundPlayer sp;
    LevelController levelController;
    BlurOptimized blurScript;
    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        //monn = GameObject.Find("computerdesk").GetComponent<Money>();
        insulin = GameObject.Find("Insulin");
        displayInsulin = insulin.GetComponentInChildren<Text>();
        sp = GetComponent<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        sDoses = levelController.doses.ToString();
        displayInsulin.text = "Doses left: " + sDoses;
        if (levelController.needToTake) {
            displayInsulin.text = "Doses left: " + sDoses + "\n You need to take insulin!";
        }
    }
    public void medicated()
    {
        //doses--;
        if (levelController.doses != 0)
        {
            levelController.doses -= 1;
            SetNeed(false);
            //sp.PlayAudio();
        } else
        {
            if(levelController.cash >= 500)
            {
                levelController.cash -= 500;
                levelController.doses += 90;
            }
        }

    }
    public void SetNeed(bool set) {
        levelController.needToTake = set;

    }
}
