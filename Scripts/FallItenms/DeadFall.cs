using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerControllerWolf>().TakeDamagePlayer();
            collision.GetComponent<PlayerControllerWolf>().TakeDamagePlayer();
            collision.GetComponent<PlayerControllerWolf>().TakeDamagePlayer();
            
            Destroy(gameObject);
        }
    }
}
