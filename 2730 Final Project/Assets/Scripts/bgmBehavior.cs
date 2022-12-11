using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmBehavior : MonoBehaviour
{
    public AudioSource bgm1;
    public AudioSource bgm2;

    public GameObject triggerBox;

    public bool triggerDisappear;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (bgm2.isPlaying == true)
        {
            bgm2.Stop();
        }
        bgm1.Play();
    }
}
