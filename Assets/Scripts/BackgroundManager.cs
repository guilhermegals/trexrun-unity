using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    #region [ Properties ]

    [SerializeField]
    private GameObject CloudObject;

    private GameObject ParentObject;

    [SerializeField]
    private GameObject[] ObstaclesObject;

    [SerializeField]
    private float[] BirdSpawnPosition;

    [SerializeField]
    private float[] CloudSpawnPosition;

    public static BackgroundManager Manager = null;

    [SerializeField]
    private float DefaultSpawnX = 9f;

    private int CheckPoints = 0;

    #endregion

    #region [ Unity Functions ]

    void Awake() {
        this.Singleton();
        this.ParentObject = GameObject.Find("Background");
        this.CheckPoints = 0;
    }

    #endregion

    #region [ Public Functions ]

    public void GenerateObstacle() {
        Random.InitState(System.DateTime.Now.Millisecond);
        GameObject obstacleObject = this.ObstaclesObject[Random.Range(0, this.ObstaclesObject.Length)];
        GameObject obstacleClone = Instantiate(obstacleObject, this.ParentObject.transform);

        Element obstacleElement = obstacleClone.GetComponent<Element>();
        obstacleElement.IncreaseSpeed(GameManager.Manager.SpeedAmount * this.CheckPoints);

        float positionY = obstacleClone.transform.position.y;
        if (obstacleElement.GetBackgroundType() == BackgroundType.Bird) {
            positionY = this.BirdSpawnPosition[Random.Range(0, 3)];
        }

        obstacleClone.transform.position = new Vector3(this.DefaultSpawnX, positionY);
    }

    public void GenerateCloud() {
        Random.InitState(System.DateTime.Now.Millisecond);
        float randomY = this.CloudSpawnPosition[Random.Range(0, 3)];

        GameObject cloudClone = Instantiate(this.CloudObject, this.ParentObject.transform);
        cloudClone.transform.position = new Vector3(this.DefaultSpawnX, randomY);
    }

    public void IncreseBackgroundSpeed(float speedAmount) {
        BackgroundElement[] elements = this.ParentObject.GetComponentsInChildren<BackgroundElement>();

        foreach (BackgroundElement element in elements) {
            element.IncreaseSpeed(speedAmount);
        }

        this.CheckPoints++;
    }

    #endregion

    #region [ Private Functions ]

    private void Singleton() {
        if (Manager == null) {
            Manager = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    #endregion

}

