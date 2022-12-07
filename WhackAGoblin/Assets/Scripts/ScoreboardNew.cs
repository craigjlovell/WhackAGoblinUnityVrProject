using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardNew : MonoBehaviour, IDataPersistence
{
    public TMP_InputField inputField;

    public float score0;
    public float score1;
    public float score2;
    public float score3;
    public float score4;

    public TextMeshProUGUI name0;
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    public TextMeshProUGUI name3;
    public TextMeshProUGUI name4;
    
    public TextMeshProUGUI score0Text;
    public TextMeshProUGUI score1Text;
    public TextMeshProUGUI score2Text;
    public TextMeshProUGUI score3Text;
    public TextMeshProUGUI score4Text;

    
    public void LoadData(GameData data)
    {
        this.score0 = data.score0;
        this.score1 = data.score1;
        this.score2 = data.score2;
        this.score3 = data.score3;
        this.score4 = data.score4;

        this.score0Text.text = data.score0text;
        this.score1Text.text = data.score1text;
        this.score2Text.text = data.score2text;
        this.score3Text.text = data.score3text;
        this.score4Text.text = data.score4text;

        this.name0.text = data.name0;
        this.name1.text = data.name1;
        this.name2.text = data.name2;
        this.name3.text = data.name3;
        this.name4.text = data.name4;
    }

    public void SaveData(ref GameData data)
    {
        data.score0 = this.score0;
        data.score1 = this.score1;
        data.score2 = this.score2;
        data.score3 = this.score3;
        data.score4 = this.score4;

        data.score0text = this.score0Text.text;
        data.score1text = this.score1Text.text;
        data.score2text = this.score2Text.text;
        data.score3text = this.score3Text.text;
        data.score4text = this.score4Text.text;

        data.name0 = this.name0.text;
        data.name1 = this.name1.text;
        data.name2 = this.name2.text;
        data.name3 = this.name3.text;
        data.name4 = this.name4.text;
    }

    public void SetScoreBoard()
    {
        if (GameController.scoreIsSet == false)
        {
            if (GameController.playerScoreAmount > score0)
            {
                score4 = score3;
                score3 = score2;
                score2 = score1;
                score1 = score0;
                score0 = GameController.playerScoreAmount;

                score4Text.text = score4.ToString();
                score3Text.text = score3.ToString();
                score2Text.text = score2.ToString();
                score1Text.text = score1.ToString();
                score0Text.text = GameController.playerScoreAmount.ToString();

                name4.text = name3.text;
                name3.text = name2.text;
                name2.text = name1.text;
                name1.text = name0.text;
                name0.text = inputField.text;

                GameController.scoreIsSet = true;
            }
            else if (GameController.playerScoreAmount > score1)
            {
                score4 = score3;
                score3 = score2;
                score2 = score1;
                score1 = GameController.playerScoreAmount;

                score4Text.text = score4.ToString();
                score3Text.text = score3.ToString();
                score2Text.text = score2.ToString();
                score1Text.text = GameController.playerScoreAmount.ToString();

                name4.text = name3.text;
                name3.text = name2.text;
                name2.text = name1.text;
                name1.text = inputField.text;

                GameController.scoreIsSet = true;
            }
            else if (GameController.playerScoreAmount > score2)
            {
                score4 = score3;
                score3 = score2;
                score2 = GameController.playerScoreAmount;

                score4Text.text = score4.ToString();
                score3Text.text = score3.ToString();
                score2Text.text = GameController.playerScoreAmount.ToString();

                name4.text = name3.text;
                name3.text = name2.text;
                name2.text = inputField.text;

                GameController.scoreIsSet = true;
            }
            else if (GameController.playerScoreAmount > score3)
            {
                score4 = score3;
                score3 = GameController.playerScoreAmount;

                score4Text.text = score4.ToString();
                score3Text.text = GameController.playerScoreAmount.ToString();

                name4.text = name3.text;
                name3.text = inputField.text;

                GameController.scoreIsSet = true;
            }
            else if (GameController.playerScoreAmount > score4)
            {
                score4 = GameController.playerScoreAmount;

                score4Text.text = GameController.playerScoreAmount.ToString();

                name4.text = inputField.text;

                GameController.scoreIsSet = true;
            }
        }

    }
}
