using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;


public class Room_Move : MonoBehaviour
{
    //variables being defined here.

    public Vector2 cameraChangeMax;
    public Vector2 cameraChangeMin;
    public Vector3 playerChange;

    private Camera_Movement cam;
    public bool needText;
    public string mapName;

    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<Camera_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this is where you change the camera position and camera lock
    //having the camera locked is a good way to keep the camera where you want it and not move around.
    private void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.CompareTag("Player") && colission.isTrigger)
        {
            cam.minLocation.x = cameraChangeMin.x;
            cam.minLocation.y = cameraChangeMin.y;
            cam.maxLocation.x = cameraChangeMax.x;
            cam.maxLocation.y = cameraChangeMax.y;
            colission.transform.position += playerChange;
            double newSmooth = 0.05;

            cam.fluidity = Convert.ToSingle(newSmooth);

            DelayCam();

            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    //IEnumerator to have a place name
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = mapName;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }


    //this is the camera delay, it delays its movement and smooths it out for a small while
    //this will give you the nice smoothing transition between rooms.
    public async void DelayCam()
    {
        // whatever you need to do before delay goes here         

        await Task.Delay(2400);

        double newSmooth = 1;

        cam.fluidity = Convert.ToSingle(newSmooth);
    }
}
