using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minTempoSpawn;
    private float ultimoSpawn;
    public GameObject inimigo;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ultimoSpawn = 0.1f;
        Debug.Log($"{TimeManager.tempoPassado} ----> {ultimoSpawn}");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.Log($"{TimeManager.tempoPassado} ----- {ultimoSpawn}");
        if (TimeManager.tempoPassado - ultimoSpawn > minTempoSpawn) {
            GameObject i = Instantiate(inimigo, new Vector2(transform.position.x + 0.5f, transform.position.y), Quaternion.identity);
            EnemyMovement em = i.GetComponent<EnemyMovement>();
            em.player = player;
            em.speed = 5;
            em.tempoSeguir = 20f;
            em.tempoSubida = 30f;
            ultimoSpawn = TimeManager.tempoPassado;
        }
    }
}
