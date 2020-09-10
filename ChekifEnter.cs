using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekifEnter : MonoBehaviour
{
    public Gateopen gto;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gto.check = false;
        }
    }
}
