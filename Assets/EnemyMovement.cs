using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveHorizontal;
    private float moveVertical;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveHorizontal = 1f;
        moveVertical = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // transform.position += transform.position + speed * Time.fixedDeltaTime * movement.normalized;
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement.normalized);  
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Parede")) {
            speed *= -1;
        }
    }
}
