using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDoor : MonoBehaviour
{
    [SerializeField]
    private Image _doorPrompt;
    GameObject mainCamera;

    bool exited;

    void Start()
    {
        _doorPrompt.enabled = false;
        mainCamera = GameObject.FindWithTag("MainCamera");
        exited = false;
    }

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.B) && exited == false)
        {
            GameObject.FindWithTag("Player").transform.position = new Vector3(155f, 0f, 165f);
            exited = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _doorPrompt.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _doorPrompt.enabled = false;
        }
    }
}
