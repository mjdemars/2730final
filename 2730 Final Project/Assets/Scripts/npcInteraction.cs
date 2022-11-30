using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcInteraction : MonoBehaviour
{
    [SerializeField]
    private Image _UIprompt;

    public AudioSource audioclip;

    void Start()
    {
        _UIprompt.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.E))
        {
            if (audioclip.isPlaying == false)
            {
                audioclip.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _UIprompt.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _UIprompt.enabled = false;
        }
    }
}
