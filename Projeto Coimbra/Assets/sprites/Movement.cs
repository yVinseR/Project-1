using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody2;
    public float movimentoHorizontal, forca;
    public bool isSensor;
    public Transform posicaoSensor;
    public LayerMask layerChao;

    void Start()
    {
        rigidBody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sensorChao();

        movimentoHorizontal = Input.GetAxisRaw("Horizontal");

        rigidBody2.velocity = new Vector2(movimentoHorizontal * 10, rigidBody2.velocity.y);

        if (Input.GetButtonDown("Jump") && isSensor==true)
        {
            rigidBody2.AddForce(new Vector2(0, forca));
        }
    }

    public void sensorChao()
    {
        isSensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.3f, layerChao);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coletavel"))
        {
            Destroy(collision.gameObject);
        }
    }
}
