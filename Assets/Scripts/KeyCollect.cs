using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    //Script to collect Keys. Attached to "Key" prefub
    public GameObject gameController;
    public AudioSource collectKeySound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            gameController.GetComponent<BuildMaze>().AddKey();
            collectKeySound.Play();
            this.gameObject.SetActive(false);
        }
    }
}
