using UnityEngine;

public class Ground : BackgroundElement {

    #region [ Properties ]

    private float SizeX;
    private GameObject GroundFather;

    #endregion

    #region [ Unity Functions ]

    private void Start() {
        this.SizeX = GetComponent<Renderer>().bounds.size.x;
    }

    private void Update() {
        this.Move();
    }

    #endregion

    #region [ Public Functions ]

    public void CreateGround() {
        GameObject ground = Instantiate<GameObject>(this.gameObject,
                                                    new Vector3(this.SizeX + this.transform.position.x, this.transform.position.y, this.transform.position.z),
                                                    this.transform.rotation);
        ground.GetComponent<Ground>().SetGroundFather(this.gameObject);
    }

    public void SetGroundFather(GameObject father) {
        if (father != null) {
            this.GroundFather = father;
            this.transform.parent = father.transform.parent;
        }
    }

    public void DestroyGroundFather() {
        if (this.GroundFather != null)
            Destroy(this.GroundFather);
    }

    #endregion

    #region [ Private Functions ]

    protected override void Move() {
        this.transform.Translate(Vector2.left * this.Speed * Time.smoothDeltaTime);
    }

    #endregion
}
