using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    
    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player"))
        {
            Score.Instance.AddCoins(10);
            Destroy(gameObject);
        }
        
    }
}
