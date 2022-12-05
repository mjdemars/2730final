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

    public AudioSource audioclip;
    public AudioSource audioclip2;
    public AudioSource audioclip3;

    public float detectionRange;
    public bool closeEnough;
    public Transform player;

    void Start()
    {
        _doorPrompt.enabled = false;
        exited = false;
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= detectionRange) {
            if (Input.GetKeyDown (KeyCode.E) && exited == false && globals.noteCounter > 0)
            {
                DoorOpen = door.transform.rotation = Quaternion.Euler(0, -90, 0);
                DoorClosed = door.transform.rotation;

                door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * smooth);
                exited = true;

                audioclip.Play();
                audioclip2.Play();
            }
            if (Input.GetKeyDown (KeyCode.E) && exited == false && globals.noteCounter < 1)
            {
                audioclip3.Play();
            }
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
