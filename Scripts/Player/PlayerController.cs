using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    HealtController healtController;
    

    
    [SerializeField] private bool isDead;
    [Header("Movimiento")]
    [SerializeField] private float speed;
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool onTheFloor;
    [SerializeField] public bool changeControll;
    [SerializeField] private Vector3 boxZize;
    
    [SerializeField] private Transform pointInitialFloor;
    [SerializeField] private LayerMask isFloor;
    [SerializeField] private Transform floorController;
    [SerializeField] private Transform pointToFloor;
    [SerializeField] public bool jump;
    //[SerializeField] private Collider2D colliderHeaderRun;
    [SerializeField] private BoxCollider2D playerCollider;
    //[SerializeField] private Collider2D colliderJump;
    [Header("Life")]
    [SerializeField] public int life;
    HeartCanvasController heartCanvasController;
    
    
    // Start is called before the first frame update
    void Awake(){
        
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healtController = GetComponent<HealtController>();
        
        isDead = false;
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            jump = true;
            //HeartCanvasController.Instance.DestroyHeart();
            //healtController.DestroyHeart();
        }

        animator.SetFloat("SpeedY",rb2D.velocity.y); 
        
    }

    private void FixedUpdate(){
        //condicion para saber que estamos en el suelo mieentra que el controlador de piso es te tocando el piso 
        if (rb2D.velocity.y >= 0)
        {
            boxZize = new Vector3(1, 0.5f, 0);
            onTheFloor = Physics2D.OverlapBox(floorController.position, boxZize, 0f, isFloor);
            animator.SetBool("OnTheFloor",onTheFloor);
        }else
        {
            boxZize = new Vector3(0, 0, 0) ;
            animator.SetBool("OnTheFloor",onTheFloor);
        }
        
        
        //Mover
        if(!isDead && jump){Movement(speed * Time.fixedDeltaTime); Jump();}

        //evitar que siempre se mande la opcion saltar    
        jump = false;
    }

    private void IsOnFloor(){   
            //floorController.position  = pointInitialFloor.position;
            //colliderJump.enabled = false;
            //colliderBodyRun.enabled = true;
            //colliderHeaderRun.enabled = true;
            playerCollider.offset = new Vector2(0.1037593f, 0.9230986f);
            floorController.position = pointInitialFloor.position;
    }
    private void Movement(float speed){
        Vector3 targetSpeed = new Vector2(speed, rb2D.velocity.y);

        //Agregar fuerza de desplasimeto a la derecha
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        animator.SetBool("Run", true);

        //direccion en la que mira el jugador
        Vector3 escale = transform.localScale;
        escale.x *= -1;
        transform.localScale = escale;

        
    }

    private void Jump(){
        if(onTheFloor && jump){
            onTheFloor = false;
            changeControll = false;
            rb2D.AddForce(new Vector2(0f, jumpForce));
            playerCollider.offset = new Vector2(0.1037593f, 2.79f);
            floorController.position = pointToFloor.position;
            
            //floorController.position = pointToFloor.position;
            //colliderBodyRun.enabled = false;
            //colliderHeaderRun.enabled = false;
            //colliderJump.enabled = true;
        }
        
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(floorController.position, boxZize);
        
    }

    public void TakeDamagePlayer(){
        HeartPool.Instance.heartList[life-1].SetActive(false);
        life--;
    }

    public void DeadPlayer(){
        if (life < 1){
            isDead = true;
            animator.SetBool("Dead",true);    
        }
        
    }
}
