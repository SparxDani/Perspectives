using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f; 
    public float moveTime = 2f; 
    private Rigidbody rb; 
    private float moveTimer; 
    private Vector3 movement;
    public int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().RestarVida();
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        SetNewMovementDirection(); 
    }

    void Update()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

        moveTimer -= Time.deltaTime;

        if (moveTimer <= 0f)
        {
            SetNewMovementDirection();
        }
    }

    void SetNewMovementDirection()
    {
        float horizontalMovement = Random.Range(-1f, 1f);
        float verticalMovement = Random.Range(-1f, 1f);
        movement = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;

        moveTimer = moveTime;
    }
}
