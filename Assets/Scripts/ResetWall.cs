using UnityEngine;

public class ResetWall : MonoBehaviour {

    #region [ Unity Functions ]

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Ground")) {
            Ground ground = collision.gameObject.GetComponent<Ground>();
            ground.CreateGround();
            ground.DestroyGroundFather();
        }else if (collision.tag.Equals("Bird") || collision.tag.Equals("Cactus") || collision.tag.Equals("Cloud")) {
            Destroy(collision.gameObject);

            if (collision.tag.Equals("Bird") || collision.tag.Equals("Cactus")) {
                BackgroundManager.Manager.GenerateObstacle();
            } else if (collision.tag.Equals("Cloud")) {
                BackgroundManager.Manager.GenerateCloud();
            }
        }
    }

    #endregion
}
