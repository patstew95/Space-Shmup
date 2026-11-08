using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
   static private Text _UI_TEXT;
    static private int  _SCORE = 0;


    void Awake() {
        _UI_TEXT = GetComponent<Text>();
        if (PlayerPrefs.HasKey("ShmupHighScore")) {
            SCORE = PlayerPrefs.GetInt("ShmupHighScore");
        }
        PlayerPrefs.SetInt("ShmupHighScore", SCORE);
    }

    static public int SCORE {
        get { return _SCORE; }
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("ShmupHighScore", value);
            if (_UI_TEXT != null) {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry) {
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos() {
        if (resetHighScoreNow) {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("ShmupHighScore", 0);
            Debug.LogWarning("PlayerPrefs HighScore reset to 0.");
        }
    }
}
