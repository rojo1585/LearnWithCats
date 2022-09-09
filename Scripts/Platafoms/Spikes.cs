using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Rigidbody2D rb2D;
    


    //[SerializeField] private Transform pointToFall;

    // Start is called before the first frame update
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start(){
        
    }

    public void Fall(){
        rb2D.gravityScale  = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            PlayerController.Instance.TakeDamagePlayer();
        }
    }
    
    
}
