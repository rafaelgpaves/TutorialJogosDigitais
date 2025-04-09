using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource auds;
    private int numTriangulos;
    private int dinheiro;
    public float speed;
    public TextMeshProUGUI txtNumTriangulos;
    public TextMeshProUGUI txtDinheiro;
    public TextMeshProUGUI txtTime;
    public GameObject triangulo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        auds = GetComponent<AudioSource>();
        numTriangulos = 0;
        dinheiro = 0;
    }

    void Update()
    {
        txtTime.text = FormatTime();
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

    private string FormatTime() {
        string tempo = "";
        int hora = (int)(Time.timeSinceLevelLoad / 3600);
        if (hora < 10) {
            tempo += "0";
        }
        tempo += hora.ToString("N0") + ":";

        int min = (int) (Time.timeSinceLevelLoad / 60);
        if (min < 10) {
            tempo += "0";
        }
        tempo += min.ToString("N0") + ":";

        float s = Time.timeSinceLevelLoad % 60;
        if (s < 10) {
            tempo += "0";
        }
        tempo += s.ToString("F2");

        return tempo;
    }
}
