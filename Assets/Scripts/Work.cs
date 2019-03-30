using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : MonoBehaviour
{
    public GameObject door;
    public GameObject money;
    public GameObject clock;
    LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        door = GameObject.Find("door");
        money = GameObject.Find("computerdesk");
        clock = GameObject.Find("clock");
    }
    public void goWork()
    {
        if (!clock.GetComponentInChildren<GameClock>().bedTime)
        {
            clock.GetComponentInChildren<GameClock>().working();//hour += 7;
            levelController.cash += 100;
        }
        else {
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
