using UnityEngine;

public class Wall : MonoBehaviour {

    #region [ Unity Functions ]

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Ground")) {
            Ground ground = collision.gameObject.GetComponent<Ground>();
            ground.CreateGround();
            ground.DestroyGroundFather();
        }else if (collision.tag.Equals("Bird") || collision.tag.Equals("Cactus")) {
            Destroy(collision.gameObject);
        }
    }

    #endregion
}
