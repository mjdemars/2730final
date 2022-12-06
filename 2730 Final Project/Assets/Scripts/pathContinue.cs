using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathContinue : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;

    Light directionalLight;

    // Start is called before the first frame update
    void Start()
    {
        directionalLight = GameObject.FindWithTag("Light").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.note1 > 0) {
            // light darkens after picking up first note
            Color darkenColor1 = new Color(0.76f, 0.73f, 0.63f, 1.0f);
            directionalLight.color = darkenColor1;

            // if interacted with BOTH note1 and fire then walls disappear and light darkens even more
            if (globals.fire == true) {
                Color darkenColor2 = new Color(0.54f, 0.51f, 0.42f, 1.0f);
                directionalLight.color = darkenColor2;
                wall1.SetActive(false);
            }

        }
        if (globals.note2 > 0) {
            // light darkens even more after second note
            Color darkenColor3 = new Color(0.31f, 0.28f, 0.23f, 1.0f);
            directionalLight.color = darkenColor3;

            // after last interaction the light goes all the way down and second wall becomes inactive
            if (globals.candymen == true) {
                Color darkenColor4 = new Color(0f, 0f, 0f, 1.0f);
                directionalLight.color = darkenColor4;
                wall2.SetActive(false);
            }
        }
    }
}
