using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayLightController : MonoBehaviour {

    private SoulCollector soulCollector;
    private Object lightPrefab, linePrefab;
    public float maxDistance = 30f;
    public bool existLine = false;
    private List<GameObject> lights;
    private GameObject line;

    public void Awake() {

        soulCollector = GameObject.FindGameObjectWithTag("Player").GetComponent<SoulCollector>();
        lights = new List<GameObject>();
        lightPrefab = Resources.Load("Prefabs/Light");
        linePrefab = Resources.Load("Prefabs/Line");
    }

    public void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector3 targetPosition = transform.position;
            GameObject lightObject = Instantiate(lightPrefab, new Vector3(targetPosition.x, targetPosition.y, 0), Quaternion.identity) as GameObject;
            lights.Add(lightObject);
            if (lights.Count != 3)
            {
                soulCollector.ChangeSouls(-1);
            }
        }

        if (lights.Count == 2 && Vector2.Distance(lights[0].transform.position, lights[1].transform.position) < maxDistance) {
            RaycastHit2D[] rayHits = Physics2D.LinecastAll(lights[0].transform.position, lights[1].transform.position, LayerMask.GetMask("RayCast"));
            Vector3 lineEnd = lights[1].transform.position;
            foreach(GameObject light in lights) {
                light.GetComponent<Animator>().SetBool("active", true);
            }
            foreach (RaycastHit2D hit in rayHits)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    // Matar al enemigo
                    hit.collider.gameObject.SendMessage("Kill", null);
                }
                if (hit.collider.gameObject.tag == "Obstacle")
                {
                    lineEnd = hit.point;
                    break;
                }
                if (hit.collider.gameObject.tag == "Brazzier") {
                    hit.collider.gameObject.SendMessage("Activate");
                }
            }
            if (!existLine) {
                line = Instantiate(linePrefab,
                new Vector3((lights[0].transform.position.x + lineEnd.x) / 2, (lights[0].transform.position.y + lineEnd.y) / 2, 0f),
                Quaternion.identity) as GameObject;
                existLine = true;
                line.GetComponent<LineRenderer>().SetPosition(0, lights[0].transform.position);
                line.GetComponent<LineRenderer>().SetPosition(1,
                    Vector2.Distance(lights[0].transform.position, lineEnd) * Vector3.Normalize(lineEnd - lights[0].transform.position) + lights[0].transform.position);
                
            }
           
        }
        if (lights.Count == 3)
        {
            Destroy(line);
            existLine = false;
            foreach (GameObject light1 in lights)
            {
                Destroy(light1);
            }
            lights.Clear();
        }
    }
}
