using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public void OpenScene(string scene) {
        Application.LoadLevel(scene);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }

    }
}
