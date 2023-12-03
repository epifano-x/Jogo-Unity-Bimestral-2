using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 10f;

    private Rigidbody rb;
    private bool isGrounded;

    private float totalDistanceX; // Distância total percorrida no eixo X
    private float accelerationMultiplier = 0.01f; // Multiplicador de aceleração por unidade de distância em X

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(moveForce * vertical, 0f, -moveForce * horizontal);

        // Ajusta a força com base na distância total percorrida no eixo X
        float adjustedMoveForce = moveForce + totalDistanceX * accelerationMultiplier;
        rb.AddForce(force * adjustedMoveForce);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
            {
                if (hit.collider.CompareTag("Plataforma"))
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    StartCoroutine(DisableGroundedForDuration(0.2f));
                }
            }
        }
    }

    IEnumerator DisableGroundedForDuration(float duration)
    {
        isGrounded = false;
        yield return new WaitForSeconds(duration);
        isGrounded = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0 && Vector3.Dot(collision.contacts[0].normal, Vector3.up) > 0.5f)
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {
        // Atualiza a distância total percorrida no eixo X
        totalDistanceX += Mathf.Abs(rb.velocity.x) * Time.fixedDeltaTime;
    }
}
