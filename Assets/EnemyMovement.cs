using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveHorizontal;
    private float moveVertical;
    public float speed;
    public GameObject player;
    public float tempoSeguir; // apos esse tempo (em segundos), inmigo passa a te seguir
    private float ultimoTempoSubida;
    public float tempoSubida; // apos esse tempo (sem segundos), inimigo aumenta velocidade

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveHorizontal = 1f;
        moveVertical = 0f;
        ultimoTempoSubida = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimeManager.tempoPassado > tempoSeguir) {
            rb.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime));
        } else {
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement.normalized);  
        }

        if (TimeManager.tempoPassado - ultimoTempoSubida > tempoSubida) {
            ultimoTempoSubida = TimeManager.tempoPassado;
            speed += 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Parede")) {
            speed *= -1;
        }
    }

    void IncreaseSpeed() {
        speed += 10;
    }
}
