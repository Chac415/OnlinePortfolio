using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
	public Text scorevalue;

    void Awake ()
    {
        score = 0;
    }


    void Update ()
    {
		scorevalue.text = "Score: " + score;
    }
}
