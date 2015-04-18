using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayLigth : MonoBehaviour {

    public GameObject light_proto;
    private List<GameObject> lights;

    public void Awake() {
        lights = new List<GameObject>();
    }

    public void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector3 targetPosition = transform.position;
            GameObject lightObject = Instantiate(light_proto, new Vector3(targetPosition.x, targetPosition.y, 0), Quaternion.identity) as GameObject;
            lights.Add(lightObject);

            if (lights.Count == 2) {
                RaycastHit2D[] rayHits = Physics2D.LinecastAll(lights[0].transform.position, lights[1].transform.position, LayerMask.GetMask("RayCast"));
                if (rayHits.Length != 0) {
                    Debug.Log("Touched");
                }

                foreach (RaycastHit2D hit in rayHits) {
                    if (hit.collider.gameObject.tag == "Enemy") {
                        // Matar al enemigo
                    }
                    if (hit.collider.gameObject.tag == "Obstacle") {
                        break;
                    }
                }
                Debug.DrawLine(lights[0].transform.position, lights[1].transform.position, Color.blue, 2);
            }

            if (lights.Count == 3) {
                foreach (GameObject light1 in lights) {
                    Destroy(light1);
                }
                lights.Clear();
            }
        }
    }
}
