using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawn : MonoBehaviour
{

    public static BookSpawn SpawnItemWorld(Vector3 position, Book book) {
        Transform transform = Instantiate(BookAssets.Instance.pfBook, position, Quaternion.identity);

        BookSpawn bookSpawn = transform.GetComponent<BookSpawn>();
        bookSpawn.SetBook(book);

        return bookSpawn;
    }

    public static BookSpawn DropItem(Vector3 dropPosition, Book book) {
        BookSpawn itemWorld = SpawnItemWorld(dropPosition, book);
        return itemWorld;
    }



    private Book book;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBook(Book book) {
        this.book = book;
        spriteRenderer.sprite = book.GetSprite();
    }

    public Book GetItem() {
        return book;
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }
}
