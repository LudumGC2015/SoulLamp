using UnityEngine;
using System.Collections;

public class BrazierBehaviour : MonoBehaviour {
    public GameObject m_activatedObject;
    public float m_timeLifeBrazier = 10.0f;
    private bool m_isActive;
    private Animator animator;

	// Use this for initialization
	void Start () {
        m_isActive = false;
        animator = GetComponent<Animator>();
	}

    IEnumerator DactivateBrazier() {
        yield return new WaitForSeconds(m_timeLifeBrazier);
        m_isActive = false;
        animator.SetBool("active", true);
        // TODO Activar animación desactivado
        //m_activatedObject.SendMessage("DeactivateObject", SendMessageOptions.RequireReceiver);
    }

    void Activate() {
        if (!m_isActive)
        {
            m_isActive = true;
            animator.SetBool("active", true);
            //m_activatedObject.SendMessage("ActivateObject", SendMessageOptions.RequireReceiver);
            // TODO Activar animación de encendido
            StartCoroutine("DactivateBrazier");
        }
    }
}
