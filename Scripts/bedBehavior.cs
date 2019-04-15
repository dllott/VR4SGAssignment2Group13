using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedBehavior : MonoBehaviour
{
    GameClock clock;
    InsulinInfo insul;
    // Start is called before the first frame update
    void Start()
    {
        clock = GameObject.Find("clock").GetComponentInChildren<GameClock>();
        insul = GameObject.Find("Insulin").GetComponent<InsulinInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sleep()
    {
        clock.sleeping();
        insul.SetNeed(true);
    }
}
