using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource auds;
    private int numTriangulos;
    static private int dinheiro;
    public float speed;
    public TextMeshProUGUI txtNumTriangulos;
    public TextMeshProUGUI txtDinheiro;
    public GameObject triangulo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        auds = GetComponent<AudioSource>();
        numTriangulos = 0;
        dinheiro = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      float moveHorizontal = Input.GetAxisRaw("Horizontal");
      float moveVertical = Input.GetAxisRaw("Vertical");

      Vector2 movement = new Vector2(moveHorizontal, moveVertical);

      rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement.normalized);  
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Coletavel")) {
            auds.Play();
            Destroy(other.gameObject);

            Instantiate(triangulo, new(Random.Range(-6.5f, 6.5f), Random.Range(-3.5f, 3.5f), 0f), Quaternion.identity);

            numTriangulos += 1;
            txtNumTriangulos.text = string.Format("{0}", numTriangulos);
        }

        if (other.CompareTag("Loja")) {
            dinheiro += numTriangulos;
            txtDinheiro.text = string.Format("Dinheiro: {0}$", dinheiro);
            numTriangulos = 0;
            txtNumTriangulos.text = string.Format("{0}", numTriangulos);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Inimigo")) {
            SceneManager.LoadSceneAsync(2);
        }   
    }

}
