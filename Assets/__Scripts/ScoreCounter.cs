using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;

    private Text uiText;

    void Start() {
        uiText = GetComponent<Text>();
    }

    void Update() {
        uiText.text = score.ToString("#,0");  // Adds commas, e.g. 1,000
    }

    public void AddPoints(int pts) {
        score += pts;
        HighScore.TRY_SET_HIGH_SCORE(score);
    }// Start is called before the first frame update
    
}
