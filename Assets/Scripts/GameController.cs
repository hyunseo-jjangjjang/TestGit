using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public ResultScript resultManager;
    public ScoreScript scoreManager;
    public CardManager cardManager;
    private StageManager stageManager;
    private TimerScript timer;
    public Text stageText;
    private int currentStage = 0;
    private int currentFinishCard = 0;
    private int finishCard;


    private Card firstCard = null;
    private Card secondCard = null;

   
    private void Start()
    {
        timer = GetComponent<TimerScript>();
        stageManager = GetComponent<StageManager>();

        timer.gameend = GameEnd;
        StageInit();

        currentStage = 0;
        Stage stage = stageManager.GetStage(currentStage);
        GameInit(stage);
    }
    private void StageInit()
    {
        stageManager.AddStage(2, 2, 20, 100);
        stageManager.AddStage(4, 2, 40, 200);
        stageManager.AddStage(6, 3, 200, 400);
    }
    private void GameInit(Stage stage)
    {
        stageText.text = (currentStage + 1) + " 스테이지";
        currentFinishCard = 0;
        cardManager.Clear();
        timer.TimerStop();

        int gridPaddingSize = (int)(965f - (stage.x * 59.5f));
        cardManager.GetComponent<GridLayoutGroup>().padding.left = gridPaddingSize;
        cardManager.GetComponent<GridLayoutGroup>().padding.right = gridPaddingSize;

        int cardLen = stage.x * stage.y;
        finishCard = cardLen;
        int[] shuffleCards = ShuffleCards(cardLen);
        for(int i = 0; i < cardLen; i++)
        {
            cardManager.createCard(shuffleCards[i], SelectCard, CheckCard);
        }

        timer.TimerStart(stage.time);
    }

     public Card[] CheckCard(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else if (secondCard == null)
        {
            secondCard = card;
        }
        else if(firstCard == secondCard)
        {
            firstCard = null;
            secondCard = null;
            return null;
        }
        else
        {
            return null;
        }

        Card[] cards = new Card[2];
        cards[0] = firstCard;
        cards[1] = secondCard;

        return cards;
    }
    public void SelectCard(Card[] cards)
    {
        if (cards[0] == null || cards[1] == null)
            return;
        if (firstCard == null || secondCard == null)
            return;

        if (firstCard.type == secondCard.type && firstCard != secondCard)
        {
            firstCard.cardImage.enabled = false;
            secondCard.cardImage.enabled = false;
            currentFinishCard += 2;
            scoreManager.AddScore(stageManager.GetStage(currentStage).score);

            if (currentFinishCard == finishCard)
                NextStage();
        }
        else
        {
            firstCard.ReFlipCard();
            secondCard.ReFlipCard();
        }

        firstCard = null;
        secondCard = null;
    }
    private void NextStage()
    {
        currentStage++;
        Stage stage = stageManager.GetStage(currentStage);
        if (stage == null)
            GameEnd(true);
        else
            GameInit(stage);
    }
    private void RetryStage()
    {
        Stage stage = stageManager.GetStage(currentStage);
        GameInit(stage);
    }
    private void GameEnd(bool isAllClear = false)
    {
        if (isAllClear)
            SoundManager.instance.PlaySound(Sounds.Win);
        else
            SoundManager.instance.PlaySound(Sounds.Lose);

        timer.TimerStop();
        resultManager.ResultWindowOpen(scoreManager.Score, isAllClear);
    }
    private int[] ShuffleCards(int cardLen)
    {
        List<int> originCards = new List<int>();
        for (int i = 0; i < cardLen; i++)
        {
            originCards.Add(i);
        }
        List<int> shuffleCards = Shuffle(originCards);
        GameManager.instance.cardSprites = Shuffle(GameManager.instance.cardSprites);

        int[] cardArray = new int[cardLen];
        for(int i = 0; i < cardLen; i++)
        {
            cardArray[shuffleCards[i]] = i / 2;
        }


        return cardArray;
    }
    private List<T> Shuffle<T>(List<T> originData)
    {
        List<T> shuffleData = new List<T>();
        int len = originData.Count;
        for (int i = 0; i < len; i++)
        {
            int index = UnityEngine.Random.Range(0, originData.Count);
            shuffleData.Add(originData[index]);
            originData.RemoveAt(index);
        }

        return shuffleData;
    }
}
