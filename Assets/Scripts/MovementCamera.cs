using UnityEngine;
using System.Collections;

public class MovementCamera : MonoBehaviour {
    public float m_smooth;
    private Vector3 m_from;
    private Vector3 m_to;
    private float m_currentTime;
    private float m_heightCamera;
    private float m_widthCamera;

    void OnEnable() {
        m_heightCamera = 2.0f * Camera.main.aspect;
        m_widthCamera = m_heightCamera * Camera.main.orthographicSize;
        m_currentTime = 0.0f;
        m_from = transform.position;
        m_to = new Vector3(transform.position.x + m_widthCamera, transform.position.y, transform.position.z);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
    }

	void Update () {
        m_currentTime = m_currentTime + Time.deltaTime;
        float m_percent = m_currentTime / m_smooth;
        if (m_percent > m_smooth) {
            m_percent = m_smooth;
        }
        transform.position = Vector3.Lerp(m_from, m_to, m_percent);

        if (transform.position == m_to) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
            enabled = false;
        }
	}
}
