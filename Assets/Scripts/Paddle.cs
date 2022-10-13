using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isBlue;
    private float limiteY = 3.0f; //Límite del movimiento de las palas verticalmente

    void Update()
    {
        float movement;

        if (isBlue)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        Vector2 paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -limiteY, limiteY);
        transform.position = paddlePosition;
    }
}
