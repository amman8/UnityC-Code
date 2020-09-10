using UnityEngine;

public class Maindoor : MonoBehaviour
{
    public Animator ani;
    public Animator ani2;
    public AudioSource aud;
    public PLAYMOVE script;
    public bool check = false;
    public bool change = false;
    private void Start()
    {
        script = GameObject.FindObjectOfType<PLAYMOVE>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            check = true;
            change = script.isopen;
            MainGateSoundPlay();
            if (change == true)
            {
                ani.SetBool("op", true);
                ani2.SetBool("op", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            check = false;
            ani.SetBool("op", false);
            ani2.SetBool("op", false);
            MainGateSoundPlay();
            script.isopen = false;
            
        }
    }

    public void MainGateSoundPlay()
    {
        aud.Play();
    }
}