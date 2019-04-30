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
    SoundPlayer sp;
    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        door = GameObject.Find("door");
        money = GameObject.Find("computerdesk");
        clock = GameObject.Find("clock");
        sp = GetComponent<SoundPlayer>();
    }
    public void goWork()
    {
        //sp.PlayAudio();
        if (!clock.GetComponentInChildren<GameClock>().bedTime)
        {
            clock.GetComponentInChildren<GameClock>().working();//hour += 7;
            levelController.cash += 100;
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
