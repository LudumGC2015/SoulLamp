using UnityEngine;
using System.Collections;

public class SoulController : MonoBehaviour {

    public SoulCollector soulCollector;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            soulCollector.ChangeSouls(1);
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
