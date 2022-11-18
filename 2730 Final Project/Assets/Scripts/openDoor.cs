using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDoor : MonoBehaviour
{
    [SerializeField]
    private Image _doorPrompt;

    public GameObject door;

    bool exited;
    public float smooth;

    private Quaternion DoorOpen;
    private Quaternion DoorClosed;

    void Start()
    {
        _doorPrompt.enabled = false;
        exited = false;
    }

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.B) && exited == false)
        {
            DoorOpen = door.transform.rotation = Quaternion.Euler(0, -90, 0);
            DoorClosed = door.transform.rotation;

            door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * smooth);
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
