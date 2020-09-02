using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardObject;
    private List<Card> cards = new List<Card>();
    private int usecardCount = 0;
    public void Clear()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].gameObject.SetActive(false);
        }
        usecardCount = 0;
    }
    public Card createCard(int type, Card.SelectCard selectCard, Card.CheckCard checkCard)
    {
        Card card = null;
        if(usecardCount == cards.Count)
        {
            card = Instantiate(cardObject, transform).GetComponent<Card>();
            cards.Add(card);
        }
        else
        {
            card = cards[usecardCount];
        }

        usecardCount++;
        card.gameObject.SetActive(true);
        card.cardImage.enabled = true;
        card.SetCard(type);
        card.selectcard = selectCard;
        card.checkcard = checkCard;
        return card;
    }
}
