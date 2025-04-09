using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI txtTime;
    static public float tempoPassado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtTime.text = FormatTime();
    }

    private string FormatTime() {
        tempoPassado = Time.timeSinceLevelLoad;
        string tempo = "";
        int hora = (int)(tempoPassado / 3600);
        if (hora < 10) {
            tempo += "0";
        }
        tempo += hora.ToString("N0") + ":";

        int min = (int) (tempoPassado / 60);
        if (min < 10) {
            tempo += "0";
        }
        tempo += min.ToString("N0") + ":";

        float s = tempoPassado % 60;
        if (s < 10) {
            tempo += "0";
        }
        tempo += s.ToString("F2");

        return tempo;
    }
}
