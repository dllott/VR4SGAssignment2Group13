using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class GoHome : MonoBehaviour
{
    public const float TIME_LIM = 360F;
    public const float TEXT_LIM = 5F;
    public Text job;

    private float timer = 0F;
    private float text_timer = 0F;
    // Start is called before the first frame update
    void Start()
    {
        job = GameObject.Find("worktext").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;


        if(this.timer >= TIME_LIM)
        {
            SceneManager.LoadScene("Main");
        }

        if(this.text_timer >= TEXT_LIM)
        {
            //job.enabled = false;
        }
    }
}
