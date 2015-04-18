using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoulCollector : MonoBehaviour
{
    private int currentSouls = 1;
    public Text soulCounter;


    void Start()
    {   
        string soulDisplay = "Souls: ";
        string.Concat(soulDisplay, currentSouls.ToString());
        soulCounter.text = soulDisplay;
    }

    public void ChangeSouls(int amount)
    {
        currentSouls += amount;
        string soulDisplay = "Souls: ";
        string.Concat(soulDisplay, currentSouls.ToString());
        soulCounter.text = soulDisplay;
    }

}
