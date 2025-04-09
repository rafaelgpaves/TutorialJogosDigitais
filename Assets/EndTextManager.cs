using TMPro;
using UnityEngine;

public class EndTextManager : MonoBehaviour
{
    public TextMeshProUGUI txtTime;
    public TextMeshProUGUI txtDinheiro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        txtTime.text = $"Tempo final: {TimeManager.tempoPassado}";
        txtDinheiro.text = $"Dinheiro total: {PlayerMovement.dinheiro}";
    }
}
