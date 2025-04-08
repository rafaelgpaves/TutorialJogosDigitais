using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource auds;
    private int score;
    // private float timePassed;
    public float speed;
    public TextMeshProUGUI txt;
    public TextMeshProUGUI txtTime;
    public GameObject triangulo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        auds = GetComponent<AudioSource>();
        score = 0;
        // timePassed = 0;
    }

    void Update()
    {
        // timePassed += Time.deltaTime;
        // txtTime.text = Time.timeSinceLevelLoad.ToString("F2");
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

            score += 1;
            txt.text = string.Format("Pontuação: {0}", score);
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
