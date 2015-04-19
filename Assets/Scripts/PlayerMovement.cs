using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    private Rigidbody2D rigidBody;
    private SoulCollector soulCollector;
    private Animator m_animator;
    private Vector2 m_direccion;
    public float maxSpeed = 6f;
    public float jumpForce = 400f;
    [SerializeField]
    private LayerMask whatIsGround;
    const float groundedRadius = .1f;
    public bool isGround;

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
        soulCollector = GetComponent<SoulCollector>();
        m_animator = GetComponent<Animator>();
        m_direccion = new Vector2(0.00f, 0.00f);
        rigidBody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);
        Move(h, jump);
        if (Physics2D.Linecast(new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), new Vector3(transform.position.x, transform.position.y - 1.001f, transform.position.z), whatIsGround))
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
