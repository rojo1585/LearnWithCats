using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int coins;

    private TextMeshProUGUI textMesh;

    private static Score instance;
    public static Score Instance {get {return instance;}}

    private void Awake(){
        if (Instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    private void Start(){
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void AddCoins(int amount){
        coins +=  amount;        
    }
    
}
