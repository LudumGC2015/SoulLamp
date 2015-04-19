using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    private Rigidbody2D rigidBody;
    private Animator m_animator;
    private Vector2 m_direccion;
    public float maxSpeed = 6f;
    public float jumpForce = 400f;
    public bool invulnerable;
    [SerializeField]
    private LayerMask whatIsGround;
    const float groundedRadius = .1f;
    public bool isGround;

    public void Move(float move, bool jump)
    {
        if (move == 0)
        {
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
        }
        m_animator.SetFloat("speedX", Mathf.Abs(move));
        rigidBody.AddRelativeForce(new Vector2(move * maxSpeed * 10, 0f));
        if (rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.AddRelativeForce(new Vector2(-move * maxSpeed * 10, 0f));
        }
        if (isGround && jump)
        {
            m_animator.SetBool("isGround", false);
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            isGround = false;
        }
    }

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_direccion = new Vector2(0.00f, 0.00f);
        rigidBody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);
        if (!invulnerable)
        {
            Move(h, jump);
        }
        if (Physics2D.Linecast(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), whatIsGround))
        {
            isGround = true;
            m_animator.SetBool("isGround", true);
        }
        else
        {
            isGround = false;
            m_animator.SetBool("isGround", false);
        }
        m_animator.SetBool("isGround", isGround);
        m_animator.SetFloat("speedY", rigidBody. velocity.y);

        if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.00f, 180.00f));
            m_animator.SetFloat("speedX", 0.02f);
            m_direccion.x = -1.00f;
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            m_animator.SetFloat("speedX", 0.00f);
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.00f, 0.00f));
            m_animator.SetFloat("speedX", 0.02f);
            m_direccion.x = 1.00f;            
        }

        if (Input.GetKeyUp("d") || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_animator.SetFloat("speedX", 0.00f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && m_animator.GetBool("isGround"))
        {
            m_animator.SetFloat("speedY", 0.02f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_animator.SetFloat("speedY", 0.00f);
        }
	
	}
}
