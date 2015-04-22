using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoulText : MonoBehaviour {
    
    private SoulCollector soulCollector;

    private Text soulText;

    public void Start() {
        soulText = GetComponent<Text>();
        soulCollector = GameObject.FindGameObjectWithTag("Player").GetComponent<SoulCollector>();
    }

    public void Update() {
        soulText.text = "Souls: " + soulCollector.GetCurrentSouls();
    }
}
