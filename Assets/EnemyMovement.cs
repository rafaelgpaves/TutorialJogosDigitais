using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource auds;
    private float moveHorizontal;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        auds = GetComponent<AudioSource>();
        moveHorizontal = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    //   float moveHorizontal = Input.GetAxisRaw("Horizontal");
    //   float moveVertical = Input.GetAxisRaw("Vertical");
    float moveVertical = 0f;

      Vector2 movement = new Vector2(moveHorizontal, moveVertical);

      rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement.normalized);  
    }

    private void OnCollisionEnter2D(Collider2D other) {
        if (other.CompareTag("Objeto")) {
            moveHorizontal *= -1;
        }
    }
}
