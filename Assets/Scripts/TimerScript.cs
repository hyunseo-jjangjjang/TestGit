using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    private float time;

    public delegate void GameEnd(bool isAllClear);
    public GameEnd gameend;

    public Text timeText;
    
    public void TimerStart(float time)
    {
        this.time = time;
        StartCoroutine("timerCoroutine");
    }
    public void TimerStop()
    {
        StopAllCoroutines();
    }
    private void SetText(float time)
    {
        timeText.text = time + "초 남았습니다.!!";
    }
    IEnumerator timerCoroutine()
    {
        SetText(time);
        while (time > 0)
        {
            yield return new WaitForSeconds(1.0f);
            time -= 1.0f;
            SetText(time);
            if (time <= 3.0f)
                timeText.color = Color.red;
            else
                timeText.color = Color.black;
        }
        gameend(false);
    }
}
