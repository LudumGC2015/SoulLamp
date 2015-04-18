using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Animator m_animator;

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("a"))
        {
            m_animator.SetFloat("speedX", 0.02f);
            m_animator.SetBool("isLeft", true);
            m_animator.SetBool("isRight", false);
        }

        if (Input.GetKeyUp("a"))
        {
            m_animator.SetFloat("speedX", 0.00f);
            m_animator.SetBool("isLeft", false);
        }

        if (Input.GetKeyDown("d"))
        {
            m_animator.SetFloat("speedX", 0.02f);
            m_animator.SetBool("isRight", true);
            m_animator.SetBool("isLeft", false);
        }

        if (Input.GetKeyUp("d"))
        {
            m_animator.SetFloat("speedX", 0.00f);
            m_animator.SetBool("isRight", false);
        }

        if (Input.GetKeyDown("space") && m_animator.GetBool("isGround"))
        {
            m_animator.SetFloat("speedY", 0.02f);
            m_animator.SetBool("isGround", false);
        }

        if (Input.GetKeyUp("space")) {
            m_animator.SetFloat("speedY", 0.00f);
        }
	
	}
}
