using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region [ Properties ]

    public static GameManager Manager;

    private GameObject GameOverText;
    private GameObject RestartButton;
    private GameObject Rex;
    private Rex RexManager;
    private ScoreHandler ScoreHandler;

    private GameObject BackgroundElements;

    private bool GameOver;
    public float SpeedAmount = 0.1f;
    public float SpeedScoreAmount = 1f;

    private float IncreaseDelay = 0.5f;
    private float NextIncrease;

    public AudioClip CheckPointSound;

    #endregion

    #region [ Unity Functions ]

    private void Awake() {
        this.Singleton();

        SceneManager.sceneLoaded += this.StartGame;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            this.RestartGame();
        }

        this.GameOver = this.RexManager.IsDead();

        if (this.GameOver) {
            this.FinishGame();
        } else {
            if (Mathf.Round(this.ScoreHandler.Score) % 100 == 0) {
                this.IncreaseVelocity();
            }
        }
    }

    #endregion

    #region [ Public Functions ]

    public void RestartGame() {
        SceneManager.LoadScene("MainScene");
    }

    #endregion

    #region [ Private Functions ]

    private void StartGame(Scene scene, LoadSceneMode mode) {
        this.GameOver = false;
        Time.timeScale = 1;

        this.ScoreHandler = GameObject.FindObjectOfType<ScoreHandler>();
        this.BackgroundElements = GameObject.FindWithTag("Background");
        this.RestartButton = GameObject.Find("RestartButton");
        this.Rex = GameObject.Find("Rex");
        this.GameOverText = GameObject.Find("GameOver");
        this.RexManager = this.Rex.GetComponent<Rex>();

        if (this.GameOverText != null)
            this.GameOverText.SetActive(false);

        if (this.RestartButton != null)
            this.RestartButton.SetActive(false);
    }

    private void IncreaseVelocity() {
        if (Time.time < this.NextIncrease)
            return;

        BackgroundElement[] elements = this.BackgroundElements.GetComponentsInChildren<BackgroundElement>();

        foreach (BackgroundElement element in elements) {
            element.IncreaseSpeed(this.SpeedAmount);
        }

        this.ScoreHandler.IncreaseScoreSpeed(this.SpeedScoreAmount);
        this.NextIncrease = Time.time + this.IncreaseDelay;
        SoundManager.Manager.PlaySound(this.CheckPointSound);
    }

    private void FinishGame() {
        this.RestartButton.SetActive(true);
        this.GameOverText.SetActive(true);
        this.ScoreHandler.IncreaseScore = false;
        this.ScoreHandler.UpdateHighScore();
        if (Time.timeScale > 0f)
            Time.timeScale -= 0.25f;
    }

    private void Singleton() {
        if (Manager == null) {
            Manager = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    #endregion
}
