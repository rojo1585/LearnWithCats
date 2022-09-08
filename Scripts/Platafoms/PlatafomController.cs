using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatafomController : MonoBehaviour
{
    private PlatformEffector2D pE2D;
    [SerializeField]private bool fallControl;
    // Start is called before the first frame update
    void Start()
    {
        pE2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            //pE2D.rotationalOffset = 180;
            //fallControl = true;
            gameObject.layer = 0;
            new WaitForSeconds(1f);
            gameObject.layer = 3;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //pE2D.rotationalOffset = 0;
        //fallControl = false;
        gameObject.layer = 3;
        
        
    }
    private void OnCollisionExit2D(Collision2D collision){
        //pE2D.rotationalOffset = 0;
        //fallControl = false;
        //gameObject.layer = 3;
        
        
    }
}
