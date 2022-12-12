using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcInteraction : MonoBehaviour
{
    [SerializeField]
    private Image _UIprompt;

    public AudioSource audioclip;
    public AudioSource audioclip2;

    public GameObject triggerBox;

    public float detectionRange;
    public bool closeEnough;
    public Transform player;

    void Start()
    {
        _UIprompt.enabled = false;
    }

    void Update()
    {
        closeEnough = false;

        if (Vector3.Distance(player.position, transform.position) <= detectionRange) {
            if(Input.GetKeyDown (KeyCode.E)) {
                globals.candymen = true;
                closeEnough = true;
                _UIprompt.enabled = false;
                if (audioclip.isPlaying == false && audioclip2.isPlaying == false) {
                    StartCoroutine(PlaySounds());
                }
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

    IEnumerator PlaySounds() {
        audioclip.Play();
        yield return new WaitForSeconds(13);
        audioclip2.Play();
        triggerBox.SetActive(false);
    }
}
