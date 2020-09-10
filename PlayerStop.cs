using UnityEngine;

public class PlayerStop : MonoBehaviour
{
    private PLAYMOVE play;
    public GameObject enemy;
    private mouse mou;
    public AudioSource aud;
    public Animator ani;
    private void Start()
    {
        play = FindObjectOfType<PLAYMOVE>();
        mou = FindObjectOfType<mouse>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            play.GateOpening();
            play.itstrue = false;
            Invoke("BackOpen", 4f);
        }
    }

    public void BackOpen()
    {
        play.itstrue = true;
        mou.mouseSensity = 130f;
        Makingactiveenemy();
    }

    public void Makingactiveenemy()
    {
        ani.SetBool("Go", true);
        enemy.SetActive(true);
        aud.Play();
        Invoke("LateInvokeFunction", 6f);
    }

    private void LateFunction()
    {
        ani.SetBool("Go", false);
    }
}