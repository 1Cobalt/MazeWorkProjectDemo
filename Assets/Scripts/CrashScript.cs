using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScript : MonoBehaviour
{
    //Script for enemies main collider - they kill player when they touch them.
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
        }
    }
}
