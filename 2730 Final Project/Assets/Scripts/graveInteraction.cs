using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class graveInteraction : MonoBehaviour
{
    [SerializeField]
    private Image _UIprompt;

    [SerializeField]
    private Image _graveImage;

    public AudioSource audioclip;
    public AudioSource audioclip2;

    public Transform player;
    public Transform target;

    public float detectionRange;
    public bool closeEnough;

    public GameObject spotlight1;
    public GameObject spotlight2;

    void Start()
    {
        _UIprompt.enabled = false;
        _graveImage.enabled = false;
    }

    void Update()
    {
      if (Vector3.Distance(player.position, target.position) <= detectionRange) {
          if(Input.GetKeyDown (KeyCode.E)) {
                closeEnough = true;
                spotlight1.GetComponent<Light>().color = Color.red;
                spotlight2.GetComponent<Light>().color = Color.red;
                _UIprompt.enabled = false;
                _graveImage.enabled = true;
                if (audioclip.isPlaying == false && audioclip2.isPlaying == false) {
                    StartCoroutine(PlayAudio());
                }
                StartCoroutine("Quit");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _UIprompt.enabled = true;
        }

        // if (Input.GetKeyDown (KeyCode.E) )
        // {
        //     spotlight1.GetComponent<Light>().color = Color.red;
        //     spotlight2.GetComponent<Light>().color = Color.red;
        //     _UIprompt.enabled = false;
        //     _graveImage.enabled = true;
        //     if (audioclip.isPlaying == false && audioclip2.isPlaying == false) {
        //         StartCoroutine(PlayAudio());
        //     }
        //     StartCoroutine("Quit");
        // }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _UIprompt.enabled = false;
        }
    }

    IEnumerator PlayAudio() {
        audioclip.Play();
        yield return new WaitForSeconds(12);
        audioclip2.Play();
    }

    IEnumerator Quit() {
        yield return new WaitForSeconds(12);
        Application.Quit();
    }
}
