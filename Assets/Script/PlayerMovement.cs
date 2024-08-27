using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI WinText;

    private Rigidbody rb;
    private int score;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

        SetScoreText();
        WinText.gameObject.SetActive(false);
        
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVecter = movementValue.Get<Vector2>();

        movementX = movementVecter.x;
        movementY = movementVecter.y;

    }

    void SetScoreText()
    {
        ScoreText.text = "Score : " +score.ToString();
        if (score >= 5) 
        {
            WinText.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX , 0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;

            SetScoreText() ;
        }
        if (other.gameObject.CompareTag("UnPickup"))
        {
            other .gameObject.SetActive(false);
            score--;
        }
    }
}
