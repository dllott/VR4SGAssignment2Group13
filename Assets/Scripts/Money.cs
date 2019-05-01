using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text displayMoney;
    public GameObject money;

    //public int cash = 500;
    string sCash;
    LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        money = GameObject.Find("computerdesk");
        displayMoney = money.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        sCash = levelController.cash.ToString();
        displayMoney.text = "Cash left: " + sCash;
    }
}
