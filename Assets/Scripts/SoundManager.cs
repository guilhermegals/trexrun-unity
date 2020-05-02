using UnityEngine;

public class SoundManager : MonoBehaviour {

    #region [ Properties ]

    public static SoundManager Manager = null;
    
    public AudioSource AudioSource;

    #endregion

    #region [ Unity Function ]

    void Awake() {
        this.Singleton();
    }

    #endregion

    #region [ Public Functions ]

    public void PlaySound(AudioClip clip) {
        this.AudioSource.clip = clip;
        this.AudioSource.Play();
    }

    #endregion

    #region [ Private Functions ]

    private void Singleton() {
        if (Manager == null) {
            Manager = this;
        } else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion
}
