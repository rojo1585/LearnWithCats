using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    
    [SerializeField] private float speed;
    private bool isDead;
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
        if(!isDead){Movement();}
      
        
    }

    private void Movement(){
        //Agregar fuerza de desplasimeto a la derecha
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        animator.SetBool("Run", true);

        //direccion en la que mira el jugador
        Vector3 escale = transform.localScale;
        escale.x *= -1;
        transform.localScale = escale;
    }
}
