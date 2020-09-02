using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Sprite> cardSprites;
    public Sprite cardBackSprite;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
}
