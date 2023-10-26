using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

    // State
    bool isAlive = true;

    // References
    Rigidbody2D mRigidbody2D;
    // gets first collider it finds on the game object
    // Collider2D mCollider2D;
    CapsuleCollider2D mCapsuleCollider2D;
    BoxCollider2D mBoxCollider2D;
    Animator mAnimator;
    Vector2 runVelocity;
    Vector2 jumpVelocity;
    Vector2 climbVelocity;
    float controlThrow;
    float gravityScaleAtStart;

    // Messages

    // Methods
    // Start is called before the first frame update
    void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        // mCollider2D = GetComponent<Collider2D>();
        mCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        mBoxCollider2D = GetComponent<BoxCollider2D>();
        mAnimator = GetComponent<Animator>();
        gravityScaleAtStart = mRigidbody2D.gravityScale;
        // mCapsuleCollider2D.enabled = true;
        // mBoxCollider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        Flip();
        Jump();
        Climb();
        Die();
    }

    private void Run()
    {
        // CrossPlatformInputManager is deprecated
        // float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        // vaulue is between -1 and 1
        controlThrow = Input.GetAxis("Horizontal");
        runVelocity = new Vector2(controlThrow * runSpeed, mRigidbody2D.velocity.y);
        mRigidbody2D.velocity = runVelocity;

        // change animation state to run
        mAnimator.SetBool("Run", HasHorizontalSpeed());
    }

    private void Flip()
    {
        // bool hasHorizontalSpeed = Mathf.Abs(mRigidbody2D.velocity.x) > Mathf.Epsilon;

        if (HasHorizontalSpeed())
        {
            // we don't want our code to rewrite the scale an only want to change its sign so multiply it with current scale
            transform.localScale = new Vector2(Mathf.Sign(mRigidbody2D.velocity.x) * Mathf.Abs(transform.localScale.x), 1f * Mathf.Abs(transform.localScale.y));
        }
    }

    private void Jump()
    {
        // jump only if the player is touching ground
        // change from collider2d to boxcollider2d (to fix wall jump)
        if (!mBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Foreground"))) { return; }
        if (Input.GetButtonDown("Jump"))
        {
            jumpVelocity = new Vector2(0f, jumpSpeed);
            mRigidbody2D.velocity += jumpVelocity;
        }
    }

    private void Climb()
    {
        // change from collider2d to capsulecollider2d
        if (!mCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Interactive")))
        {
            mAnimator.SetBool("Climb", false);
            mRigidbody2D.gravityScale = gravityScaleAtStart;
            return;
        }
        controlThrow = Input.GetAxis("Vertical");
        climbVelocity = new Vector2(mRigidbody2D.velocity.x, controlThrow * climbSpeed);
        mRigidbody2D.velocity = climbVelocity;
        mRigidbody2D.gravityScale = 0f;

        // change animation state to climb
        mAnimator.SetBool("Climb", HasVerticalSpeed());
    }

    private void Die()
    {
        if (mCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            mAnimator.SetTrigger("Die");
            mRigidbody2D.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
            // Physics.IgnoreLayerCollision(8, 10);
            // mCapsuleCollider2D.enabled = false;
            // mBoxCollider2D.enabled = false;
            // GetComponent<Rigidbody2D>().velocity = deathKick;
        }
    }

    private bool HasHorizontalSpeed()
    {
        return Mathf.Abs(mRigidbody2D.velocity.x) > Mathf.Epsilon;
    }

    private bool HasVerticalSpeed()
    {
        return Mathf.Abs(mRigidbody2D.velocity.y) > Mathf.Epsilon;
    }
}
