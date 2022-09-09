using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    private Score score;
    private int value;
    void Start()
    {
        value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyCoin(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player"))
        {
            Score.Instance.AddCoins(value);
            
            DestroyCoin();
        }
    }
}
