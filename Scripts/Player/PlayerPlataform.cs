using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlataform : MonoBehaviour
{

    private GameObject currentPlatform;

    [SerializeField] private BoxCollider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentPlatform != null)
            {
                StartCoroutine(DisabeCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Platform")){
            currentPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Platform")){
            currentPlatform = null;
        }
    }

    private IEnumerator DisabeCollision(){
        BoxCollider2D platformCollider = currentPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    
    }


}
