using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

    public string nextScene;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            GetComponent<ChangeScene>().OpenScene(nextScene);
        }
    }
}
