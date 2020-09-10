using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateopen : MonoBehaviour
{
    public Animator gateop;
    public Animator gatoprn;
    public bool check = true;
    public bool gat = false;
    public AudioSource aud1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(check == true)
            {
                gat = true;
                gateop.SetBool("lc", gat);
                gatoprn.SetBool("rc", gat);
                aud1.Play();
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (check == true)
            {
                gat = false;
                gateop.SetBool("lc", gat);
                gatoprn.SetBool("rc", gat);
                aud1.Play();
            }
        }
    }
}
