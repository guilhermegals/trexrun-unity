using UnityEngine;

public abstract class BackgroundElement : MonoBehaviour{

    #region [ Properties ]

    [SerializeField]
    protected float Speed = 1f;

    [SerializeField]
    private BackgroundType Type;

    [SerializeField]
    private bool IncreaseElementSpeed = false;

    #endregion

    #region [ Protected Functions ]

    protected abstract void Move();

    #endregion

    #region [ Public Functions ]

    public void IncreaseSpeed(float amount) {
        if(this.IncreaseElementSpeed)
            this.Speed += amount;
    }

    public BackgroundType GetBackgroundType() {
        return this.Type;
    }

    #endregion
}
