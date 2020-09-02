using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public readonly int x;
    public readonly int y;
    public readonly int time;
    public readonly int score;

    public Stage(int x, int y, int time, int targetScore)
    {
        this.x = x;
        this.y = y;
        this.time = time;
        this.score = targetScore;
    }
}
public class StageManager : MonoBehaviour
{
    private List<Stage> stages = new List<Stage>();

    public void AddStage(int x, int y, int time, int targetScore)
    {
        if((x*y)%2 == 1)
        {
            Debug.LogWarning("Stage 재설정 필요");
            x++;
        }
        Stage stage = new Stage(x, y, time, targetScore);
        stages.Add(stage);
    }

    public Stage GetStage(int stageNumber)
    {
        if (stages.Count == stageNumber)
            return null;

        return stages[stageNumber];
    }
}
