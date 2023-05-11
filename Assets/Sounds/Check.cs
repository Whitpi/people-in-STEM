using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Check : MonoBehaviour
{
    //Ðitas script'as reikalingas tam, kad einant ið vieno lygio á kità, patikrintø ar yra garsas
    //ar nëra, nes be ðio script'o varnelë ðalia Sound atsiranda net jei ir garsas iðjungtas.
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        if(AudioListener.volume == 0) //Jei garsas = 0
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
