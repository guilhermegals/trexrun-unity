using UnityEngine;

public class Element : BackgroundElement {

    #region [ Unity Functions ]

    void Start() {

    }

    private void Update() {
        this.Move();
    }

    #endregion

    #region [ Private Functions ]

    protected override void Move() {
        this.transform.Translate(Vector2.left * this.Speed * Time.smoothDeltaTime);
    }

    #endregion
}
