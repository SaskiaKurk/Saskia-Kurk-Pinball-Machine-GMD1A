using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour{

    public static int tellen = 0;
    public Text tekst;
    public int score;
    public Button knop;

    public void OnCollisionEnter(Collision collision)

    {
        Score.tellen = Score.tellen + 10;
        tekst.text = Score.tellen.ToString();
    }
}
