using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedBehavior : MonoBehaviour
{
    GameClock clock;
    InsulinInfo insul;
    LevelController level;
    bool justSlept = false;
    SoundPlayer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SoundPlayer>();
        clock = GameObject.Find("clock").GetComponentInChildren<GameClock>();
        insul = GameObject.Find("Insulin").GetComponent<InsulinInfo>();
        level = GameObject.Find("LevelController").GetComponent<LevelController>();
    }

    void resetSleep()
    {
        justSlept = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sleep()
    {
        //prevent double sleep
        if (!justSlept)
        {
            level.fadeOut = true;
            clock.working();
            insul.SetNeed(true);
            justSlept = true;
            Invoke("resetSleep", 5);
        }
        else
        {
            //do something to indicate the user is not tired enough to sleep yet
        }
    }
}
