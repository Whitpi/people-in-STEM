using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   [SerializeField]
   private Book book;

   [SerializeField]
   SpriteRenderer spriteRenderer;

    private void OnValidate() {
    
        SetupGameObject();
    
   }

   void SetupGameObject()
   {
        if(book == null) return;
        SetGameSprite();
   }

   void SetGameSprite()
   {
        spriteRenderer.sprite = book.GameSprite;
   }

    public void SetBook(Book book)
   {
        this.book = book;
        spriteRenderer.sprite = book.GameSprite;
   }

   public Book GetBook()
   {
        return book;
   }
}
