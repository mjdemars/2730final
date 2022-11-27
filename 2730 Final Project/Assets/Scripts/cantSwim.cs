using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cantSwim : MonoBehaviour 
{
    public float detectionRange ;
    public bool closeEnough ;
    public Transform player;

    [SerializeField] GameObject myCanvas;
    public Transform target;
    public Transform cam;
     
     // cam and player are the same
    void Start ()   
    {
        cam = Camera.main.transform;
    }        
 

    void Update() 
    {
        closeEnough = false;
        myCanvas.SetActive(false);

        if (Vector3.Distance(player.position, transform.position) <= detectionRange) {
            closeEnough = true;
            myCanvas.SetActive(true);
            //sets canvas to rotate towards player always
            myCanvas.transform.LookAt(myCanvas.transform.position + cam.forward, Vector3.up);
        }
    }
}