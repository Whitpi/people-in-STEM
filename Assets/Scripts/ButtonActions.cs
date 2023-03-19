using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public Canvas infoScreen;

    //Exists info screen
    public void ExitInfoSceen()
    {
        infoScreen.gameObject.SetActive(false);
    }
}
