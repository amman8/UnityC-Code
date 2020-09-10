using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorChair : MonoBehaviour 
{
    public Animator ani;
    public AudioSource ads;
    public bool allow = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ani.SetBool("ch", allow);
            ads.Play();
        }
    }
}
