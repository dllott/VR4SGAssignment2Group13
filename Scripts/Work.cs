using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            clock.GetComponentInChildren<GameClock>().working();//hour += 4;
            levelController.cash += 30;
        }
        else {
        }
        SceneManager.LoadScene(sceneName: "Work");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
