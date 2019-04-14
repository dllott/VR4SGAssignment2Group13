using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stacking : MonoBehaviour
{
    Vector3 temp;
    public GameObject unstacked;
    public GameObject stacked;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        unstacked = GameObject.Find("unstacked");
        stacked = GameObject.Find("stacked");
        temp = new Vector3(0, 0.02f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stack()
    {

        unstacked.gameObject.transform.localScale -= temp;
        stacked.gameObject.transform.localScale += temp;
        count++;

        if(count == 10)
        {
            SceneManager.LoadScene("Main");
        }

    }
}
