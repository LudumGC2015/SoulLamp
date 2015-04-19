using UnityEngine;
using System.Collections;

public class DeathEnemy : MonoBehaviour {

    Object soulPrefab;

    void Awake() {
        soulPrefab = Resources.Load("Prefabs/Soul");
    }

    void Kill() {
        Destroy(gameObject);
        GameObject soul = Instantiate(soulPrefab, transform.position, Quaternion.identity) as GameObject;
        soul.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 400f));
    }
}
