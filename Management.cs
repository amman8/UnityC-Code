using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public GameObject LIGHTNING;
    public GameObject Flickring;

    private void OnTriggerEnter(Collider other)
    {
        LIGHTNING.SetActive(false);
        Flickring.SetActive(false);
    }
}
