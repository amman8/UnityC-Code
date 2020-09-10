using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSwitch : MonoBehaviour
{
    private void Start()
    {
        Invoke("SceanSwitch", 9f);
    }

    public void SceanSwitch ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
