using UnityEngine;

public class EnvournmentSound : MonoBehaviour
{ 
    public AudioSource Begning;
    public AudioSource NightForest;
    

    private void Start()
    {
        Begning.Play();
        Invoke("LateSound", 40f);
    }

    void LateSound()
    {
        NightForest.Play();
    }
}
