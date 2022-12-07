using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public string score0text;
    public string score1text;
    public string score2text;
    public string score3text;
    public string score4text;

    public string name0;
    public string name1;
    public string name2;
    public string name3;
    public string name4;

    public float score0;
    public float score1;
    public float score2;
    public float score3;
    public float score4;

    public GameData()
    {
        this.score0 = 0;
        this.score1 = 0;
        this.score2 = 0;
        this.score3 = 0;
        this.score4 = 0;

        this.score0text = "-";
        this.score1text = "-";
        this.score2text = "-";
        this.score3text = "-";
        this.score4text = "-";

        this.name0 = "-";
        this.name1 = "-";
        this.name2 = "-";
        this.name3 = "-";
        this.name4 = "-";
    }
}
