using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoulCollector : MonoBehaviour
{
    private int currentSouls = 1;
    public Text soulCounter;

    void Start()
    {   
        soulCounter.text = "Souls: " + currentSouls;
    }

    public void ChangeSouls(int amount)
    {
        currentSouls += amount;
        soulCounter.text = "Souls: " + currentSouls;
    }
}
