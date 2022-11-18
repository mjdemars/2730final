using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noteAppear : MonoBehaviour
{
    [SerializeField]
    private Image _ingredientsImage;

    GameObject mainCamera;
    bool pickedUp;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        pickedUp = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pickedUp) {
            drop();
        } else {
            pickup();
        }
    }

    void pickup() {
        if(Input.GetKeyDown (KeyCode.E)) {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                _ingredientsImage.enabled = true;
                pickedUp = true;
            }
        }
    }

    void drop() {
        if(Input.GetKeyDown (KeyCode.E)) {
            _ingredientsImage.enabled = false;
            pickedUp = false;
        }
    }


        // void OnTriggerEnter(Collider other) {
    //     if (other.CompareTag("Player")) {
    //         if(Input.GetKeyDown (KeyCode.E)) {
    //             _ingredientsImage.enabled = true;
    //         }
    //     }
    // }

    // void OnTriggerExit(Collider other) {
    //      if (other.CompareTag("Player")) {
    //         _ingredientsImage.enabled = false;
    //     }
    // }

}
