using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void RestartGame() {
        GameManager.Manager.RestartGame();
    }
}
