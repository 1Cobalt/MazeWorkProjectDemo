using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public GameObject gameController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            gameController.GetComponent<BuildMaze>().AddKey();
            this.gameObject.SetActive(false);
        }
    }
}
