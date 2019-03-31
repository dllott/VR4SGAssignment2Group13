using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoHome : MonoBehaviour
{
    public const float TIME_LIM = 10F;

    private float timer = 0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;

        if(this.timer >= TIME_LIM)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
