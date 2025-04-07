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
        txtTime.text = formatTime();
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

    private string formatTime() {
        string tempo = "";
        int hora = (int)(Time.timeSinceLevelLoad / 3600);
        if (hora >= 1) {
            tempo += string.Format("{0} h, ", hora);
        } 

        int min = (int) (Time.timeSinceLevelLoad / 60);
        if (min >= 1 || hora >= 1) {
            tempo += string.Format("{0} m, ", min);
        }

        float s = Time.timeSinceLevelLoad % 60;
        tempo += s.ToString("F2") + " s";

        return tempo;
    }
}
