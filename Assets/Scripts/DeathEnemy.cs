using UnityEngine;
using System.Collections;

public class DeathEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Kill() {
        Destroy(gameObject);
    }
}
