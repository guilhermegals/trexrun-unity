using UnityEngine;

public class Rex : MonoBehaviour {

    #region [ Properties ]

    public float JumpForce;
    public Transform OnGroundCheck;

    private bool OnGround = true;
    private bool Jumping = false;
    private bool Lowering = false;
    private bool Dead = false;
    private Rigidbody2D Rigidbody;
    private Animator Animator;

    #endregion

    #region [ Unity Functions ]

    private void Start() {
        this.Rigidbody = GetComponent<Rigidbody2D>();
        this.Animator = GetComponent<Animator>();
    }

    private void Update() {
        this.OnGround = Physics2D.Linecast(this.transform.position, this.OnGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && this.OnGround) {
            this.Jumping = true;
        }

        this.Lowering = Input.GetKey(KeyCode.DownArrow);

        this.UpdateAnimations();
    }

    private void FixedUpdate() {
        if (this.Jumping) {
            this.Jump();
        }

        if (this.Lowering && !this.OnGround) {
            this.Fall();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Bird") || collision.tag.Equals("Cactus")) {
            this.Die();
        }
    }

    #endregion

    #region [ Private Functions ]

    private void Jump() {
        this.Rigidbody.AddForce(new Vector2(0, this.JumpForce));
        this.Jumping = false;
    }

    private void Fall() {
        this.Rigidbody.AddForce(new Vector2(0, -(this.JumpForce / 3)));
        this.Jumping = false;
    }

    private void UpdateAnimations() {
        this.Animator.SetBool("Running", true);
        this.Animator.SetBool("Jumping", !this.OnGround);
        this.Animator.SetBool("Running", this.OnGround);
        this.Animator.SetBool("Lowering", (this.Lowering && this.OnGround));
        this.Animator.SetBool("Dead", this.Dead);
    }

    private void Die() {
        this.Dead = true;
    }

    #endregion
}
