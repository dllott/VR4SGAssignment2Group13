using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{

    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = /*1 -*/ (gvrTimer / totalTime);
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));


          //This is for later on when we are adding the events
                if(Physics.Raycast(ray, out _hit, distanceOfRay))
                {
                    if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("fridge"))
                    {
                _hit.transform.gameObject.GetComponent<Health>().Eat();
                gvrTimer = 0;
                     
                    }

                    if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("bed"))
                    {
                        _hit.transform.gameObject.GetComponent<bedBehavior>().Sleep();
                        gvrTimer = 0;

                    }

                    if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("insulin"))
                    {
                        _hit.transform.gameObject.GetComponent<InsulinInfo>().medicated();
                        gvrTimer = 0;

                    }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("door"))
                    {
                        _hit.transform.gameObject.GetComponent<Work>().goWork();
                gvrTimer = 0;


            }/*
                    if (imgGaze.fillAmount == 0 && _hit.transform.CompareTag("teleportGood"))
                    {
                        _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayerGood();
                    }
                    if (imgGaze.fillAmount == 0 && _hit.transform.CompareTag("return"))
                    {
                        _hit.transform.gameObject.GetComponent<Teleport>().returnHome();
                    }*/
        }
         
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
