using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public GameObject footstep;
    private bool isGrounded = false; // Karakterin zeminle temas durumunu kontrol eden de�i�ken
    private bool isMoving = false; // Karakterin hareket halinde olup olmad���n� kontrol eden de�i�ken

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKey("a") || Input.GetKey("d"))
            {
                if (!isMoving)
                {
                    footsteps();
                }
                isMoving = true;
            }
            else
            {
                StopFootsteps();
                isMoving = false;
            }
        }
        else
        {
            // Karakter havadayken ayak seslerini durdur
            StopFootsteps();
            isMoving = false;
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Karakter zemine temas ederse isGrounded true yap�l�r
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if (Input.GetKey("a") || Input.GetKey("d"))
            {
                footsteps();
                isMoving = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Karakter zeminle temas�n� kaybederse isGrounded false yap�l�r
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            StopFootsteps();
            isMoving = false;
        }
    }
}
