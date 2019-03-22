using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int cash = 500;
    public int hour= 7;
    public int minutes = 0;
    public string dayNight = "A.M.";
    public bool bedTime = false;
    public bool needToTake = false;
    public float _hunger = 0.0f;
    public int doses = 10;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("control");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
