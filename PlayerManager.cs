using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;

    public void PlayerDie()
    {
        Invoke("SceanChange",4f);
        Cursor.lockState = CursorLockMode.Confined;
    }

    void SceanChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}