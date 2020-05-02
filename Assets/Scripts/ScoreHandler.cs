using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

    #region [ Properties ]

    public Text ScoreText;
    public Text HighScoreText;

    [HideInInspector]
    public float Score;
    [HideInInspector]
    public float HighScore;
    [HideInInspector]
    public bool IncreaseScore;
    public bool CheckPoint = false;
    public float PointsPerSecond;

    #endregion

    #region [ Unity Functions ]

    void Start() {
        this.IncreaseScore = true;
        this.Score = 1;
        this.HighScore = PlayerPrefs.GetFloat("HighScore");

        if (this.HighScore <= 0)
            this.HighScoreText.gameObject.SetActive(false);

        this.HighScoreText.text = "HI " + Mathf.Round(this.HighScore).ToString().PadLeft(5, '0');
    }


    void Update() {
        if (this.IncreaseScore) {
            this.Score += this.PointsPerSecond * Time.deltaTime;
        }
        if (!this.CheckPoint) {
            this.ScoreText.text = Mathf.Round(this.Score).ToString().PadLeft(5, '0');
        }

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

            if (!this.HighScoreText.IsActive())
                this.HighScoreText.gameObject.SetActive(true);
        }
    }

    public IEnumerator CheckPointEffect() {
        this.CheckPoint = true;
        for (float i = 0f; i < 0.5f; i += 0.1f) {
            this.ScoreText.enabled = false;
            yield return new WaitForSeconds(0.1f);
            this.ScoreText.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        this.CheckPoint = false;
    }

    #endregion
}
