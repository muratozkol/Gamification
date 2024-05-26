using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    Rigidbody2D rigid;
    public float h�z;
    public float z�plamaGucu;
    Vector3 hareket;
    Animator anim;
    private GameManager gameManager;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameManager = GameManager.instance;
    }

    void Update()
    {
        hareket = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += hareket * h�z * Time.deltaTime;
        anim.SetFloat("H�z", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rigid.velocity.y, 0))
        {
            rigid.AddForce(Vector3.up * z�plamaGucu, ForceMode2D.Impulse);
            anim.SetBool("Z�plama", true);
        }

        if (anim.GetBool("Z�plama") && Mathf.Approximately(rigid.velocity.y, 0))
        {
            anim.SetBool("Z�plama", false);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            gameManager.CheckBox(collision.gameObject);
        }
        if (collision.gameObject.tag == "Tuzak")
        {
            gameManager.PlayerHitTrap(true); // 'true' parametresini ge�iyoruz
        }
    }
}
