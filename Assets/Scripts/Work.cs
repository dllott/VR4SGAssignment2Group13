using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : MonoBehaviour
{
    public GameObject door;
    public GameObject money;
    public GameObject clock;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("door");
        money = GameObject.Find("computerdesk");
        clock = GameObject.Find("clock");
    }
    public void goWork()
    {
        clock.GetComponentInChildren<GameClock>().working();//hour += 7;
        money.GetComponent<Money>().cash += 100;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
