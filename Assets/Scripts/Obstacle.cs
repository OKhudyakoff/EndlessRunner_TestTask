using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Start()
    {
        GOSetActiveFalse();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    private void GOSetActiveFalse()
    {
        StartCoroutine(TimeBeforeActiveFalse());
        gameObject.SetActive(false);
    }

    private IEnumerator TimeBeforeActiveFalse()
    {
        yield return new WaitForSeconds(40f);
    }
}
