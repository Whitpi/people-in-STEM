using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Book
{
    public enum BookType
    {
        Red,
        Blue,
        Green,
        Yellow,
    }

    public BookType bookType;

    public Sprite GetSprite()
    {
        switch (bookType)
        {
            default:
            case BookType.Red: return BookAssets.Instance.redSprite;
            case BookType.Blue: return BookAssets.Instance.blueSprite;
            case BookType.Green: return BookAssets.Instance.greenSprite;
            case BookType.Yellow: return BookAssets.Instance.yellowSprite;
        }
    }
}
