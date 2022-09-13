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
    private bool jump;
    
    [Header("Life")]
    public bool isDead;
    public int life;

    
    
    

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
    }

    void FixedUpdate(){
        animator.SetBool("OnTheFloor", IsOnFloor());
        if(!isDead){Movement(speed * Time.fixedDeltaTime); Jump();}
        animator.SetFloat("SpeedY",rb2D.velocity.y); 
        jump = false;

    }

    public void Jump(){
        if(IsOnFloor() && jump){
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public bool IsOnFloor(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, new Vector2(playerCollider.bounds.size.x, playerCollider.bounds.size.y), 0f, Vector2.down, 0.2f, isFloor);
        return raycastHit.collider != null;

    }

    private void Movement(float speed){
        Vector3 targetSpeed = new Vector2(speed, rb2D.velocity.y);

        //Agregar fuerza de desplasimeto a la derecha
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(IsOnFloor()){animator.SetBool("Run", true);}else{animator.SetBool("Run", false);}
        
    }

    public void TakeDamagePlayer(){
        if(life > 0){
            HeartPool.Instance.heartList[life-1].SetActive(false);
            animator.SetTrigger("TakeHit");
        }
        
        life--;
        if(life <= 0){
            DeadPlayer();
        }
    }
    public void AddLife(){
        if(life < 3){
            HeartPool.Instance.heartList[life].SetActive(true);
            life++;
        }
        
    }

    public void DeadPlayer(){
        isDead = true;
        animator.SetBool("Dead",true);
    }
}
