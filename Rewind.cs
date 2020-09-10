using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{

    public bool isRewinding = false;
    List<PointinTime> pointintime;
    void Start()
    {
        pointintime = new List<PointinTime>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        if(Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }
        
    }

    private void FixedUpdate()
    {
        if (isRewinding == true && PlayerDamage.currentHealth > 0)
        {
            Rwind();
        }
        else
        {
            Record();
        }
    }

    void Rwind()
    {
        if(pointintime.Count>0)
        {
            PointinTime pointsinTime = pointintime[0];
            transform.position = pointsinTime.position;
            transform.rotation = pointsinTime.rotation;
            pointintime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    void Record ()
    {
        if(pointintime.Count> Mathf.Round(10f/Time.fixedDeltaTime))
        {
            pointintime.RemoveAt(pointintime.Count - 1);
        }
        pointintime.Insert(0, new PointinTime(transform.position, transform.rotation));
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false; 
    }
}
