using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndIntro : MonoBehaviour
{

    void Transition()
    {
        Debug.Log("Intro Ended");
        SceneManager.LoadScene("Scenes/Main");
    }
    // Use this for initialization
    void Start()
    {
        Invoke("Transition", 7);
    }

}