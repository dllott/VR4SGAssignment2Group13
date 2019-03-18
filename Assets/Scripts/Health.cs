using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour
{
    //public static Health h;
    public UnityEngine.UI.Slider _healthSlider;
    public GameObject fridge; //= GameObject.Find("fridge");
    public GameObject insulin;
    public GameObject money;
    public RectTransform Fridgescreen = null;
    public  float _hunger = 0.0f;
    double secondsSinceStart;
    // Start is called before the first frame update

    void Start()
    {
        _hunger = 0;
        fridge = GameObject.Find("fridge");
        insulin = GameObject.Find("Insulin");
        money = GameObject.Find("computerdesk");
        _healthSlider = fridge.GetComponentInChildren<Slider>();

        
        InvokeRepeating("CountHunger", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Time.time - secondsSinceStart > 5.0)
        {
            _hunger++;
        }*/
        _healthSlider.value = (float)_hunger / 20;
        //secondsSinceStart++;
        /*if(secondsSinceStart == 5)
        {
            Eat();
        }*/
    }
    void CountHunger()
    {
        _hunger++;
        //secondsSinceStart++;
    }
    public void Eat()
    {
        _hunger = 0.0f;
        _healthSlider.value = 0;
        insulin.GetComponent<InsulinInfo>().doses -= 1;
        money.GetComponent<Money>().cash -= 50;

    }
}
