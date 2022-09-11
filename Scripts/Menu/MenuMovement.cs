using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    private float mousePosX;
    private float mousePosY;
    [SerializeField]private float movementForce;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2((mousePosX / Screen.width) * movementForce + (Screen.width / 2), (mousePosY / Screen.height) * movementForce + (Screen.height / 2));
    }
}
