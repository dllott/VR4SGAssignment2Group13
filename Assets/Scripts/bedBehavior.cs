using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedBehavior : MonoBehaviour
{
    GameClock clock;
    InsulinInfo insul;
    SoundPlayer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SoundPlayer>();
        clock = GameObject.Find("clock").GetComponentInChildren<GameClock>();
        insul = GameObject.Find("Insulin").GetComponent<InsulinInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sleep()
    {
        sp.PlayAudio();
        clock.working();
        insul.SetNeed(true);
    }
}
