using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAfterScrolling : MonoBehaviour
{
    public Scrollbar bar;
    public Button continueButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //When scroll bar reaches end it shows continue button otherwise it
        //does not show it 
        if (bar.value <= 0)
        {
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(false);
        }
    }
}
