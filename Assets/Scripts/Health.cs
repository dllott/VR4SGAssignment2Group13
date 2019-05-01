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
    public GameClock gclock;
    public RectTransform Fridgescreen = null;
    //public  float _hunger = 0.0f;
    double secondsSinceStart;
    LevelController levelController;

    SoundPlayer sp;
    // Start is called before the first frame update

    void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        //_hunger = 0;
        fridge = GameObject.Find("fridge");
        insulin = GameObject.Find("Insulin");
        money = GameObject.Find("computerdesk");
        _healthSlider = fridge.GetComponentInChildren<Slider>();
        gclock = GameObject.Find("clock").GetComponentInChildren<GameClock>();

        sp = GetComponent<SoundPlayer>();
        //InvokeRepeating("CountHunger", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Time.time - secondsSinceStart > 5.0)
        {
            _hunger++;
        }*/
        _healthSlider.value = (float)levelController._hunger / 5;
        //secondsSinceStart++;
        /*if(secondsSinceStart == 5)
        {
            Eat();
        }*/
    }
    public void CountHunger(int c)
    {
        levelController._hunger+=c;
        //secondsSinceStart++;
    }
    public void Eat()
    {

        //sp.PlayAudio();
        levelController._hunger -= 10.0f;
        if(levelController._hunger < 0) {
            levelController._hunger = 0;
        }
        _healthSlider.value = 0;
        insulin.GetComponent<InsulinInfo>().SetNeed(true);

        fridge.GetComponent<Dizzy>().Shake();
        levelController.cash -= 50;
        gclock.MoveTime(1);
    }
}
