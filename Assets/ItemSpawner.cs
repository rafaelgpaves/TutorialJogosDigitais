using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour
{
    private AudioSource auds;
    public float minDistance;
    private float ultimoX;
    private float ultimoY;
    private int maxItems;
    public GameObject triangulo;
    private List<GameObject> triangulos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        auds = GetComponent<AudioSource>();
        ultimoX = 0f;
        ultimoY = 0f;
        maxItems = 4;
        triangulos = new List<GameObject>():
        
        while (triangulos.length < maxItems) {
            SpawnTriangle();
        }
    }

    void Update()
    {
        while (triangulos.length < maxItems) {
            SpawnTriangle();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void SpawnTriangle() {
        float x = Random.Range(-6.5f, 6.5f);
        float y = Random.Range(-3.5f, 3.5f);
        while (new Vector2(x, y).sqrMagnitude < minDistance * minDistance) {
            float x = Random.Range(-6.5f, 6.5f);
            float y = Random.Range(-3.5f, 3.5f);
        }
        triangulos.add(Instantiate(triangulo, new(x, y, 0f), Quaternion.identity));
        ultimoX = x;
        ultimoY = y;
    }
}
