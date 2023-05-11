using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPC : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TMP_Text Dialogas;
    public string[] dialogas;
    private int index;

    public GameObject Continue;
    public float wordspeed;
    public bool playerIsClose;
    // Update is called once per frame
    [SerializeField] private AudioSource continuesoundeffect;
    [SerializeField] private AudioSource typingsoundeffect;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&& playerIsClose)
        {
            if(DialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                DialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(Dialogas.text == dialogas[index] )
        {
            Continue.SetActive(true);
        }
    }
    //Tuðèia dialogo dëþë
    public void zeroText()
    {
        Dialogas.text = "";
        index = 0;
        DialoguePanel.SetActive(false);
    }

    //Raidþiø raðymo efektas
    IEnumerator Typing()
    {
        foreach(char letter in dialogas[index].ToCharArray())
        {

            Dialogas.text += letter;
            yield return new WaitForSeconds(wordspeed);
            typingsoundeffect.Play();
        }

    }
    public void NextLine()
    {
        continuesoundeffect.Play();
        Continue.SetActive(false);

        if(index < dialogas.Length - 1)
        {
            index++;
            Dialogas.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }

    }
    //Du metodai patikrina ar þaidëjas yra arti
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
