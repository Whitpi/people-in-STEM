using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Check : MonoBehaviour
{
    //�itas script'as reikalingas tam, kad einant i� vieno lygio � kit�, patikrint� ar yra garsas
    //ar n�ra, nes be �io script'o varnel� �alia Sound atsiranda net jei ir garsas i�jungtas.
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
