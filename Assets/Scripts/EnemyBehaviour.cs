using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private bool moveToPlayer = false;
    public GameObject player;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            moveToPlayer = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            moveToPlayer = false;
        }
    }
    //When enemy in "Trigger radius" of player - it will approach player. The closer it goes - the slower is enemy speed
    private void Update() 
    {
        if (moveToPlayer)
        {
            Vector3 direction = new Vector3((this.transform.localPosition.x - player.transform.localPosition.x)*1.3f, (this.transform.localPosition.y - player.transform.localPosition.y) * 1.3f, (this.transform.localPosition.z - player.transform.localPosition.z) * 1.3f);
            _rb.MovePosition(_rb.position + (-1*direction) * Time.deltaTime);
        }
    }
}
