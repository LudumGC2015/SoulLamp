using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Animator m_animator;
    private Vector2 m_direccion;

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
        m_direccion = new Vector2(0.00f, 0.00f);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("a"))
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.00f, 180.00f));
            m_animator.SetFloat("speedX", 0.02f);
            m_direccion.x = -1.00f;
        }

        if (Input.GetKeyUp("a"))
        {
            m_animator.SetFloat("speedX", 0.00f);
        }

        if (Input.GetKeyDown("d"))
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.00f, 0.00f));
            m_animator.SetFloat("speedX", 0.02f);
            m_direccion.x = 1.00f;            
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
