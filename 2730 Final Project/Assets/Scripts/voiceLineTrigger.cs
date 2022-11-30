using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceLineTrigger : MonoBehaviour
{
    public AudioSource voiceline;
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
        if (voiceline.isPlaying == false)
        {
            voiceline.Play();
        }
    }
}
