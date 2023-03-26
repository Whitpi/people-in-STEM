using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableBook", fileName = "New Scriptable Book")]
public class Book : ScriptableObject
{
    public enum BookTypes
    {
        Red,
        Blue,
        Green,
        Yellow,
    }
    
    [SerializeField]
    string name;

    [SerializeField]
    Sprite gameSprite;

    [SerializeField]
    Sprite uiSprite;

    [SerializeField]
    BookTypes bookType;

    public string Name => name;
    public Sprite GameSprite => gameSprite;
    public Sprite UiSprite => uiSprite;
    public BookTypes BookType => bookType;

}
