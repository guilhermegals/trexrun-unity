using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region [ Properties ]

    public static GameManager Manager;

    [SerializeField]
    private GameObject RestartButton;
    [SerializeField]
    private GameObject TRex;
    private Rex TRexManager;

    private GameObject BackgroundElements;

    private bool GameOver;
    public int Score;
    public int HighScore;

    #endregion

    #region [ Unity Functions ]

    private void Awake() {
        this.Singleton();

        SceneManager.sceneLoaded += this.StartGame;
    }

    private void Update() {
        this.GameOver = this.TRexManager.IsDead();

        if (this.GameOver) {
            this.FinishGame();
        } else {
            this.IncreaseVelocity();
        }
    }

    #endregion

    #region [ Private Functions ]

    private void StartGame(Scene scene, LoadSceneMode mode) {
        this.GameOver = false;
        this.Score = 0;
        Time.timeScale = 1;
        this.RestartButton.SetActive(false);

        this.TRexManager = this.TRex.GetComponent<Rex>();
        this.BackgroundElements = GameObject.FindWithTag("Background");
    }

    private void IncreaseVelocity() {
       
    }

    private void FinishGame() {
        this.RestartButton.SetActive(true);
        if(Time.timeScale > 0f)
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
