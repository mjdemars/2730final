using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathContinue : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (globals.fire == true && globals.note1 > 0) {
            wall1.SetActive(false);
            RenderSettings.fogColor = Color.black;
        }
        if (globals.candymen == true && globals.note2 > 0) {
            wall2.SetActive(false);
        }
    }
}
