using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementBird();
    }
    
    private void MovementBird(){
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision ){
        if(collision.CompareTag("Player")){
            PlayerController.Instance.TakeDamagePlayer();
        }
    }
}
