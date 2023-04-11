using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject obj;
    public string sceneName;

    //Detects collisions and when it collides with a specific object -
    //loads other scene
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == obj.name)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
