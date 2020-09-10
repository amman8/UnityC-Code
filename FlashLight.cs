using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject FlashLightObject;
    public bool lightison = true;

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            lightison = !lightison;
            if (lightison == false)
            {
                FlashLightObject.SetActive(false);
            }
            if (lightison == true)
            {
                FlashLightObject.SetActive(true);
            }
        }
    }
}
