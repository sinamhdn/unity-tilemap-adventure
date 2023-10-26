using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D mRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        mRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if facing right go to right and if facing left go left
        if (IsFacingRight())
        {
            mRigidBody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            mRigidBody2D.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // flip the enemy when hit the wall
        transform.localScale = new Vector2(-(Mathf.Sign(mRigidBody2D.velocity.x) * Mathf.Abs(transform.localScale.x)), 1 * Mathf.Abs(transform.localScale.y));
    }

    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
}
