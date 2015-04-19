using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

    void Shoot(GameObject obj, Vector2 direction) {
        Vector2 vectorAngle = new Vector2(0.0f, Vector2.Angle(new Vector2(1.0f, 0.0f), direction));
        Instantiate(obj, transform.position, Quaternion.Euler(vectorAngle));
    }
}
