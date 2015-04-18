using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Animator m_animator;
    private Vector2 m_direccion;
    public float maxSpeed = 6f;
    public float jumpForce = 400f;
    [SerializeField]
    private LayerMask whatIsGround;
    private Transform groundCheck;
    const float groundedRadius = .1f;
    public bool isGround;
    private Rigidbody2D rigidBody;
    private bool facingRight = true;

    public void Move(float move, bool jump)
    {
        m_animator.SetFloat("speedX", Mathf.Abs(move));
        rigidBody.velocity = new Vector2(move * maxSpeed, rigidBody.velocity.y);
        if (isGround && jump)
        {
            m_animator.SetBool("isGround", false);
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            isGround = false;
        }
    }

    void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
        m_animator = GetComponent<Animator>();
        m_direccion = new Vector2(0.00f, 0.00f);
        rigidBody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);
        Move(h, jump);
        if (Physics2D.Linecast(new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), new Vector3(transform.position.x, transform.position.y - 1.01f, transform.position.z), whatIsGround))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        m_animator.SetBool("isGround", isGround);
        m_animator.SetFloat("speedY", rigidBody. velocity.y);

        if (Input.GetKeyDown("a"))
        {
            m_animator.SetFloat("speedX", 0.02f);
            m_direccion.x = -1.00f;
            transform.rotation = Quaternion.Euler(new Vector2(0.00f, 180.00f));
        }

        if (Input.GetKeyUp("a"))
        {
            m_animator.SetFloat("speedX", 0.00f);
            transform.rotation = Quaternion.Euler(new Vector2(0.00f, 0.00f));
        }

        if (Input.GetKeyDown("d"))
        {
            m_animator.SetFloat("speedX", 0.02f);
            m_direccion.x = 1.00f;
            transform.rotation = Quaternion.Euler(new Vector2(0.00f, 0.00f));
        }

        if (Input.GetKeyUp("d"))
        {
            m_animator.SetFloat("speedX", 0.00f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && m_animator.GetBool("isGround"))
        {
            m_animator.SetFloat("speedY", 0.01f);
            m_animator.SetBool("isGround", false);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_animator.SetFloat("speedY", 0.00f);
            m_animator.SetBool("isGround", true);
        }
	
	}
}
