using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noteAppear : MonoBehaviour
{
    [SerializeField]
    private Image _noteImage;

    GameObject mainCamera;
    public GameObject noteObject;

    bool pickedUp;
    public bool twoAudios;

    public AudioSource voiceline;
    public AudioSource voiceline2;

    public float detectionRange;
    public bool closeEnough;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        closeEnough = false;

        if(pickedUp) {
            drop();
        } else {
            pickup();
        }
    }

    void pickup() {
        if(Input.GetKeyDown (KeyCode.E)) {
            if (Vector3.Distance(player.position, transform.position) <= detectionRange) {

                closeEnough = true;

                voiceline.Play();
                if (twoAudios == true && voiceline.isPlaying == false) {
                    voiceline2.Play();
                }

                int x = Screen.width / 2;
                int y = Screen.height / 2;

                Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit)) {
                    _noteImage.enabled = true;
                    pickedUp = true;
                }
            }
        }
    }

    void drop() {
        if(Input.GetKeyDown (KeyCode.E)) {
            _noteImage.enabled = false;

            noteObject.SetActive(false);
            pickedUp = false;
        }
    }

}
