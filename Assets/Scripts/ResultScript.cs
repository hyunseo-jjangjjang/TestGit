using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class ResultScript : MonoBehaviour
{
    public Text mainText;
    public Text scoreText;

    public void ResultWindowOpen(int score, bool isAllClear = true)
    {
        if (isAllClear)
            mainText.text = "축하합니다.!!\n 모든 스테이지를 클리어 하셨습니다.";
        else
            mainText.text = "아쉽게도...\n 스테이지를 모두 클리어하지 못했습니다.";

        scoreText.text = score + "점";

        GetComponent<Animator>().SetTrigger("Start");
    }
}
