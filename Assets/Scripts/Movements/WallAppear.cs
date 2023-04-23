using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAppear : MonoBehaviour
{
    public BoxCollider2D sienosAtsiradimas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Palietus triggerá, iðjungiamas sienos trigger ir ji tampa nepereinama
    public void OnTriggerEnter2D(Collider2D collision)
    {
        sienosAtsiradimas.isTrigger = false;
    }
}
    