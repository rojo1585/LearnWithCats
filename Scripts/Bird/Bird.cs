using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator animator;
    [SerializeField] private BoxCollider2D birCollider;
    [SerializeField] private float speed;
    private bool dead;
    [SerializeField]private bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementBird();
    }
    
    private void MovementBird(){
        //transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        if (dead)
        {
            DeadBird();
        }else{
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }

    private void DeadBird(){
        animator.SetBool("Dead", true);
        rb2D.gravityScale = 1;
        if (onGround)
        {
            birCollider.enabled = true;
            
        }else{transform.Translate(Vector3.left * speed * Time.deltaTime);}
        
    }

    private void OnTriggerEnter2D(Collider2D collision ){
        if(collision.CompareTag("Player")){
            dead = true;
            collision.GetComponent<PlayerControllerWolf>().TakeDamagePlayer();
        }
        if (collision.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
