using TMPro;
using UnityEngine;

public class EndTextManager : MonoBehaviour
{
    public TextMeshProUGUI txtTime;
    public TextMeshProUGUI txtDinheiro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        string tempo = "";
        int hora = (int)(TimeManager.tempoPassado / 3600);
        if (hora < 10) {
            tempo += "0";
        }
        tempo += hora.ToString("N0") + ":";

        int min = (int) (TimeManager.tempoPassado / 60);
        if (min < 10) {
            tempo += "0";
        }
        tempo += min.ToString("N0") + ":";

        float s = TimeManager.tempoPassado % 60;
        if (s < 10) {
            tempo += "0";
        }
        tempo += s.ToString("F2");
        txtTime.text = $"Tempo final: {tempo}";

        txtDinheiro.text = $"Dinheiro total: {PlayerMovement.dinheiro}$";
    }
}
