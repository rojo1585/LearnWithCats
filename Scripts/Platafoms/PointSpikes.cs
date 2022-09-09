using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpikes : MonoBehaviour
{
    Spikes spikes;

    private void Start(){
        spikes = GameObject.Find("Spikes").GetComponent<Spikes>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player"))
        {
            spikes.Fall();
            Destroy(gameObject);
        }
    }
}
