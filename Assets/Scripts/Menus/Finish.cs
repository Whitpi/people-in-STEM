using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    //Scriptas paspaudus bet kurį mygtuką grąžiną žaidėją į pagrindinį meniu

    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.anyKeyDown && !Input.GetKey(KeyCode.UpArrow)) || (Time.timeSinceLevelLoad > 1 && Input.anyKeyDown))
            SceneManager.LoadScene("MainMenu");
    }
}
