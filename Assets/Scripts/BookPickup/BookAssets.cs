using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton class(only one in entire project)
/// </summary>
public class BookAssets : MonoBehaviour
{
    public static BookAssets Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }


    public Transform pfBook;

    public Sprite greenSprite;
    public Sprite redSprite;
    public Sprite blueSprite;
    public Sprite yellowSprite;
}
