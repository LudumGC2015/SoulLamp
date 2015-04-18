using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayLigth : MonoBehaviour {

    public Object lightPrefab, linePrefab;
    public float maxDistance = 3f;
    private List<GameObject> lights;
    private GameObject line;

    public void Awake() {
        lights = new List<GameObject>();
    }

    public void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector3 targetPosition = transform.position;
            GameObject lightObject = Instantiate(lightPrefab, new Vector3(targetPosition.x, targetPosition.y, 0), Quaternion.identity) as GameObject;
            lights.Add(lightObject);

            if (lights.Count == 2 && Vector2.Distance(lights[0].transform.position, lights[1].transform.position) < maxDistance) {
                RaycastHit2D[] rayHits = Physics2D.LinecastAll(lights[0].transform.position, lights[1].transform.position, LayerMask.GetMask("RayCast"));
                Vector3 lineEnd = lights[1].transform.position;
                foreach (RaycastHit2D hit in rayHits) {
                    if (hit.collider.gameObject.tag == "Enemy") {
                        // Matar al enemigo
                        hit.collider.gameObject.SendMessage("kill", null);
                    }
                    if (hit.collider.gameObject.tag == "Obstacle") {
                        lineEnd = hit.point;
                        break;
                    }
                }
                line = Instantiate(linePrefab,
                    new Vector3((lights[0].transform.position.x + lineEnd.x) / 2, (lights[0].transform.position.y + lineEnd.y) / 2, 0f), 
                    Quaternion.identity) as GameObject;
                line.GetComponent<LineRenderer>().SetPosition(0, lights[0].transform.position);
                line.GetComponent<LineRenderer>().SetPosition(1,
                    Vector2.Distance(lights[0].transform.position, lineEnd) * Vector3.Normalize(lineEnd - lights[0].transform.position) + lights[0].transform.position);
            }
            if (lights.Count == 3) {
                Destroy(line);
                foreach (GameObject light1 in lights) {
                    Destroy(light1);
                }
                lights.Clear();
            }
        }
    }
}
