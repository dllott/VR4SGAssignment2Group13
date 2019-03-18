using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//based on https://answers.unity.com/questions/796881/c-how-can-i-let-something-happen-after-a-small-del.html
public class GoTo1 : MonoBehaviour {

    void Transition()
    {
        Debug.Log("Scene Transition time");
        SceneManager.LoadScene("Assets/Main");
    }
    // Use this for initialization
    void Start () {
        Invoke("Transition", 15);
	}

}
