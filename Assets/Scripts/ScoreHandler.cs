using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

    #region [ Properties ]

    public Text ScoreText;
    public Text HighScoreText;

    public float Score;
    public float HighScore;
    public float PointsPerSecond;
    public bool IncreaseScore;

    #endregion

    #region [ Unity Functions ]

    void Start() {
        this.IncreaseScore = true;
        this.Score = 1;
        this.HighScore = PlayerPrefs.GetFloat("HighScore");
        this.HighScoreText.text = "HI 00" + Mathf.Round(this.HighScore);
    }


    void Update() {
        if (this.IncreaseScore) {
            this.Score += this.PointsPerSecond * Time.deltaTime;
        }
        this.ScoreText.text = "00" + Mathf.Round(this.Score);
    }

    #endregion

    #region [ Public Functions ]

    public void IncreaseScoreSpeed(float amount) {
        this.PointsPerSecond += amount;
    }

    public void UpdateHighScore() {
        if (this.Score > this.HighScore) {
            this.HighScore = this.Score;
            PlayerPrefs.SetFloat("HighScore", this.HighScore);
        }
    }

    #endregion
}
