using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;


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
    private BlurOptimized blurScript;
    public bool dying = false;
    public Image darken;
    private Color c;

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
        GameObject player = GameObject.Find("Player");
        GameObject camera = player.transform.Find("Main Camera").gameObject;
        blurScript = camera.GetComponent<BlurOptimized>();
        c = darken.color;
        c.a = 0;
        darken.color = c;
    }

    void Update()
    {
        if (c.a < 0.2f)
        {
            c.a += Time.deltaTime*0.1f;
            darken.color = c;
        }
        if (needToTake && !dying)
        {
            blurScript.downsample = 1;
            blurScript.blurSize = 1;
            blurScript.blurIterations = 1;

        }
        if (_hunger >= 25)
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
                dying = true;
                blurScript.blurSize = 3;
                blurScript.blurIterations = 2;
                //EndGame();
            }
        } else
        {
            DaysWithoutInsulin = 0;
        }
    }
}
