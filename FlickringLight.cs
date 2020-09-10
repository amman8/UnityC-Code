using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickringLight : MonoBehaviour
{
    public bool isFlickring = false;
    public float timeDelay;

    private void Update()
    {
        if (isFlickring == false)
        {
            StartCoroutine(FlickingLight());
        }
    }

    IEnumerator FlickingLight()
    {
        isFlickring = false;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(1f, 800f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(100f, 1000f);
        yield return new WaitForSeconds(timeDelay);
        isFlickring = false;
    }
}
