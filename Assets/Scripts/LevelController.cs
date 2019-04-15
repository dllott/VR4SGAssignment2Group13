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
    public Text introduction;
    private Color c;
    public bool fadeIn = true;
    public bool fadeOut = false;
    private bool slowFade = true;

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
        darken.fillAmount = 1;
        c = darken.color;
        fadeIn = true;
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled.
        //Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
        GameObject player = GameObject.Find("Player");
        darken = GameObject.Find("DarkenImage").GetComponent<Image>();
        introduction = GameObject.Find("introtext").GetComponent<Text>();
        GameObject camera = player.transform.Find("Main Camera").gameObject;
        blurScript = camera.GetComponent<BlurOptimized>();
        
    }

    void Update()
    {
        if (fadeIn)
        {
            if (slowFade) c.a -= Time.deltaTime * 0.1f;
            else c.a -= Time.deltaTime * 0.5f;
            darken.color = c;
            if (c.a < 0.01f)
            {
                slowFade = false;
                introduction.enabled = false;
                fadeIn = false;
            }
        }
        //fadeOut currently fades out then back in, because I think that's the behavior we want, but that can be changed
        if (fadeOut)
        {
            c.a += Time.deltaTime * 0.5f;
            darken.color = c;
        }
        
        if(c.a > .99f)
        {
            fadeOut = false;
            fadeIn = true;
        }

        if (!needToTake)
        {
            blurScript.blurSize = 0;
            blurScript.downsample = 0;
            blurScript.blurIterations = 1;
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
