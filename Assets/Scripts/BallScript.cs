using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    IEnumerator DestroyAfter(int seconds)
    {
        int count = seconds;
        yield return new WaitForSeconds(5);
        
        Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            StartCoroutine(DestroyAfter(1));
        }
    }
}
