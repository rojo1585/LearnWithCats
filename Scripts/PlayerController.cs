using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    

    
    [SerializeField] private bool isDead;
    [Header("Movimiento")]
    [SerializeField] private float speed;
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool onTheFloor;
    [SerializeField] private Vector3 boxZize;
    [SerializeField] private LayerMask isFloor;
    [SerializeField] private Transform floorController;
    [SerializeField] private bool jump;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }

        animator.SetFloat("SpeedY",rb2D.velocity.y); 
        
    }

    private void FixedUpdate(){
        //condicion para saber que estamos en el suelo mieentra que el controlador de piso es te tocando el piso 
        onTheFloor = Physics2D.OverlapBox(floorController.position, boxZize, 0f, isFloor);
        animator.SetBool("OnTheFloor",onTheFloor);

        //Mover
        if(!isDead){Movement(speed * Time.fixedDeltaTime, jump);}

        //evitar que siempre se mande la opcion saltar    
        jump = false;
    }


    private void Movement(float speed,bool jump){
        Vector3 targetSpeed = new Vector2(speed, rb2D.velocity.y);

        //Agregar fuerza de desplasimeto a la derecha
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        animator.SetBool("Run", true);

        //direccion en la que mira el jugador
        Vector3 escale = transform.localScale;
        escale.x *= -1;
        transform.localScale = escale;

        if(onTheFloor && jump){
            onTheFloor = false;
            rb2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void OnDrawGizmos(){
     Gizmos.color = Color.green;
        Gizmos.DrawWireCube(floorController.position, boxZize);
    }

}
