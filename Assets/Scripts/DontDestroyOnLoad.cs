using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{

    void Update()
    {
        if (gameObject.name == "Player")
        {
            GameObject obj = GameObject.FindGameObjectWithTag("playerloc");
            transform.position = obj.transform.position;
        }
    }
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(this.gameObject.tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }
}
