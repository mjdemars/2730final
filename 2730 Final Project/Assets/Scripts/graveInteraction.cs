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

    public bool pickup;

    public Image blackoutScreen;

    public GameObject spotlight1;
    public GameObject spotlight2;

    void Start()
    {
        _UIprompt.enabled = false;
        _graveImage.enabled = false;
        pickup = false;
    }

    void Update()
    {
        if (Vector3.Distance(player.position, target.position) <= detectionRange) {
            if(Input.GetKeyDown (KeyCode.E) && pickup == false) {
                closeEnough = true;
                pickup = true;

                spotlight1.GetComponent<Light>().color = Color.red;
                spotlight2.GetComponent<Light>().color = Color.red;
                _UIprompt.enabled = false;
                _graveImage.enabled = true;
                if (audioclip.isPlaying == false && audioclip2.isPlaying == false) {
                    StartCoroutine(PlayAudio());
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && pickup == false)
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

    IEnumerator PlayAudio() {
        audioclip.Play();
        yield return new WaitForSeconds(7);
        audioclip2.Play();
        yield return new WaitForSeconds(5);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut() {
        Color objectColor = blackoutScreen.GetComponent<Image>().color;
        float fadeAmount;
        // blackoutScreen.enabled = true;

        while (blackoutScreen.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (1 * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.g, fadeAmount);
            blackoutScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        // yield return new WaitForSeconds(5);
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
