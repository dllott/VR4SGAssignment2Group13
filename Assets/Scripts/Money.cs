using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text displayMoney;
    public GameObject money;
    public int cash = 500;
    string sCash;
    // Start is called before the first frame update
    void Start()
    {
        money = GameObject.Find("computerdesk");
        displayMoney = money.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        sCash = cash.ToString();
        displayMoney.text = "Cash left: " + sCash;
    }
}
