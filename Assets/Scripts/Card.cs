using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public delegate Card[] CheckCard(Card card);
    public CheckCard checkcard;
    public delegate void SelectCard(Card[] cards);
    public SelectCard selectcard;
    private Card[] beforeClickCards = new Card[2];

    private int cardType;
    public int type
    {
        get { return cardType; }
    }
    private bool flipState = false;
    public Image cardImage;

    public void select()
    {
        selectcard(beforeClickCards);
    }
    public void SetCard(int cardType)
    {
        this.cardType = cardType;
        cardImage.sprite = GameManager.instance.cardBackSprite;
    }

    public void flipCard()
    {
        Card[] cards = checkcard(this);
        if (cards == null)
            return;

        beforeClickCards = cards;
        flipState = true;
        Debug.Log("hihih");
        gameObject.GetComponent<Animator>().SetBool("Flip", flipState);
    }
    public void ReFlipCard()
    {
        flipState = false;
        gameObject.GetComponent<Animator>().SetBool("Flip", flipState);
    }

    void flipChangeImage()
    {
        if (flipState)
            cardImage.sprite = GameManager.instance.cardSprites[cardType];
        else
            cardImage.sprite = GameManager.instance.cardBackSprite;
    }
}
