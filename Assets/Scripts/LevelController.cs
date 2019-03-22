using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int cash = 500;
    public int Day = 0;
    public int hour= 7;
    public int minutes = 0;
    public string dayNight = "A.M.";
    public bool bedTime = false;
    public bool needToTake = false;
    public float _hunger = 0.0f;
    public int doses = 10;
    bool growling = false;
    public int DaysWithoutInsulin = 0;

    //Variables to supply in the editor
    [SerializeField] public Scene endscene;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("control");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(_hunger >= 25)
        {
            //play stomach growling sounds, do other things??
            if (!growling)
            {
                growling = true;
                //Play audio here
            }

            if (_hunger >= 50)
            {
                EndGame();
            }
        }


        
    }

    public void EndGame() {
        //scene fade transition instead?
        SceneManager.LoadScene(endscene.name);
    }

    public void IncrementDay()
    {
        Day++;
        if (needToTake)
        {
            //activate effects here
            DaysWithoutInsulin++;
            if(DaysWithoutInsulin > 1)
            {
                EndGame();
            }
        } else
        {
            DaysWithoutInsulin = 0;
        }
    }
}
