using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f; //Velocidad con la que empieza la bola
    [SerializeField] private float velocityMultiplier = 1.1f; //Velocidad que va aumentando cada vez que toca las palas


    private Rigidbody2D ballRb; //Se declara la pelota para el RB
    private AudioSource soundsGame; //Se declaran los sonidos
    public AudioClip choquePalas; //Se declara el sonido de goles
    public AudioClip points; //Se declara el sonido del choque de bola-palas

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>(); //Al comenzar el juego se aplican las características del RB dadas a la pelota
        soundsGame = GetComponent<AudioSource>(); //El juego va a estar a la espera de que ocurran las cosas para reproducir los sonidos
        Launch();   //Se llama a la función de abajo para que empiece al iniciar el juego
    }

    private void Launch() //Para que se mueva en direcciones random en X e Y
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Paddle"))
        {
            ballRb.velocity *= velocityMultiplier; //Cada vez que la bola colisiona con las palas, las cuales tienen el Tag Pala, mutiplican por 1.1 su velocidad.
            soundsGame.PlayOneShot(choquePalas); //Suena la música
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoalBlue"))
        {
            CreateManager.Instance.BlueScored(); //Si la bola colisiona con GoalBlue o el muro dcho, el jugador azul gana un punto.
            soundsGame.PlayOneShot(points, 0.5f);
        }

        else //Si la bola colisiona con GoalRed o el muro izq, el jugador rojo gana un punto.
        {
            CreateManager.Instance.RedScored();
            soundsGame.PlayOneShot(points, 0.5f);
        } 

        CreateManager.Instance.Restart(); //En ambos casos se reinicia la bola en el centro del campo
        Launch(); //Se vuelve a mover la bola en cualquier dirección random en los ejes X e Y

    }
}
