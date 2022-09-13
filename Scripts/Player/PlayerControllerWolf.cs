using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWolf : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    private BoxCollider2D playerCollider;
    
    [SerializeField] private LayerMask isFloor;
    [Header("Movement")]
    [SerializeField] private float speed;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool onTheFloor;
    
    [Header("Life")]
    public bool isDead;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        Jump();
        animator.SetFloat("SpeedY",rb2D.velocity.y); 
    }

    void FixedUpdate(){
        animator.SetBool("OnTheFloor", IsOnFloor());
        if(!isDead){Movement(speed * Time.fixedDeltaTime); Jump();}

    }

    public void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && IsOnFloor()){
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }

    private bool IsOnFloor(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, new Vector2(playerCollider.bounds.size.x, playerCollider.bounds.size.y), 0f, Vector2.down, 0.2f, isFloor);
        return raycastHit.collider != null;

    }

    private void Movement(float speed){
        Vector3 targetSpeed = new Vector2(speed, rb2D.velocity.y);

        //Agregar fuerza de desplasimeto a la derecha
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        animator.SetBool("Run", true);

        
    }
}
