using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public Vector2 closedMarker;
    public Vector2 openMarker;
    private Vector2 startMarker;
    private Vector3 endMarker;
    public float speed = 1.0f;
    public float fracJourney;
    private float timer;
    private float startTime;
    private bool moving = false;
    void Start()
    {
        closedMarker = GetComponent<Transform>().position;
        openMarker = new Vector2(closedMarker.x, closedMarker.y + 2f);
        startMarker = closedMarker;
        endMarker = closedMarker;
    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            ActivateObject();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DeactivateObject();
        }*/
        if (moving)
        {
            float distCovered = (Time.time - startTime) * speed;
            fracJourney = distCovered / 2;
            transform.position = Vector2.Lerp(startMarker, endMarker, fracJourney);
            if (fracJourney >= 1)
            {
                moving = false;
            }
        }
    }
    
    public void ActivateObject()
    {
        startMarker = transform.position;
        endMarker = openMarker;
        startTime = Time.time;
        moving = true;
    }

    public void DeactivateObject()
    {
        startMarker = transform.position;
        endMarker = closedMarker;
        startTime = Time.time;
        moving = true;
    }

}
