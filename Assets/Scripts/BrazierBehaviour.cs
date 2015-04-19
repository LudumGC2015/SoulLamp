using UnityEngine;
using System.Collections;

public class BrazierBehaviour : MonoBehaviour {
    public GameObject m_activatedObject;
    public float m_timeLifeBrazier = 10.0f;

    private bool m_isActive;

	// Use this for initialization
	void Start () {
        m_isActive = false;
	}

    void ActivateBrazier() {
        if (!m_isActive) {
            m_isActive = true;
            m_activatedObject.SendMessage("ActivateObject", SendMessageOptions.RequireReceiver);
            // TODO Activar animación de encendido
            StartCoroutine("DactivateBrazier");
        }
    }

    IEnumerator DactivateBrazier() {
        yield return new WaitForSeconds(m_timeLifeBrazier);
        m_isActive = false;
        // TODO Activar animación desactivado
        m_activatedObject.SendMessage("DeactivateObject", SendMessageOptions.RequireReceiver);
    }
}
