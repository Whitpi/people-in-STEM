using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawn : MonoBehaviour
{
    [SerializeField]
    public Book bookToSpawn;

    [SerializeField]
    private GameObject bookPrefab;

    public void SetBook(Book book) {
        bookToSpawn = book;
        Item prefabBook = bookPrefab.GetComponent<Item>();
        prefabBook.SetBook(bookToSpawn);
    }

    public GameObject GetBookPrefab() {
        return bookPrefab;
    }

    public Book GetBookInfo() {
        return bookToSpawn;
    }
    
    public void RemoveBook()
    {
        bookToSpawn = null;
    }
}
