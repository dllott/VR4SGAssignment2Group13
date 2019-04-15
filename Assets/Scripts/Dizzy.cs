using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dizzy : MonoBehaviour
{
    private float timer = 0.0f;
    private int shakeSpeed = 50;
    private int numberOfShakes = 100;
    public Camera camera;
    Vector3 originalPosition;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        temp = new Vector3(1000.0f, 0, 0);
        originalPosition = Camera.main.transform.position;

    }


    public void Shake()
    {
        while(numberOfShakes != 0)
    {
        Camera.main.transform.position -= temp;
        numberOfShakes--;
        Camera.main.transform.position = originalPosition;
    }
}

}
