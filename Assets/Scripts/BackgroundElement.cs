using UnityEngine;

public abstract class BackgroundElement : MonoBehaviour{

    #region [ Properties ]

    [SerializeField]
    public float Speed = 1f;

    #endregion

    #region [ Protected Functions ]

    protected abstract void Move();

    #endregion
}
