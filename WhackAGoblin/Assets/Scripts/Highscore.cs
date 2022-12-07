using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;
public class Highscore : MonoBehaviour
{
    public TextAsset textJSON;
    [System.Serializable]
    public class Player
    {
        public string name;
        public int score;
    }
    [System.Serializable]
    public class HighscoreList
    {
        public List<Player> list;
    }
    public Player myPlayer = new Player();
    public HighscoreList highscoreList = new HighscoreList();
    [SerializeField]
    private Text scoreText, highScoreText;
    public List<TextMeshProUGUI> highscoreListText = new List<TextMeshProUGUI>();
    public TextMeshProUGUI finalScore;
    public TMP_InputField playerNameInput;
    public GameObject tokenUI;
    public TextMeshProUGUI tokenReward;
    public GameObject tokenPrefab;
    public Transform tokenSpawn;
    public int m_timeBonus;
    public int tokens;
    private void Start()
    {
        highscoreList = JsonUtility.FromJson<HighscoreList>(textJSON.text);
        highScoreText.text = "High Score: \n" + highscoreList.list[0].score.ToString();
        myPlayer.name = "";
    }
    private void Update()
    {
        scoreText.text = "Score: \n" + myPlayer.score;
        finalScore.text = "Score: " + myPlayer.score;
    }
    public void TotalScore()
    {
        myPlayer.score += myPlayer.score * m_timeBonus;
        if (myPlayer.score > 15000)
            tokens = 100;
        else
            tokens = myPlayer.score / 150;
        tokenReward.text = tokens.ToString();
    }
    public void SetName()
    {
        myPlayer.name = playerNameInput.text;
        SortHighscores();
    }
    public void SortHighscores()
    {
        highscoreList.list.Add(myPlayer);
        highscoreList.list = highscoreList.list.OrderBy(x => x.score).ToList();
        highscoreList.list.Reverse();
        if (highscoreList.list.Count > 5)
            highscoreList.list.RemoveAt(5);
        for (int i = 0; i < 5; i++)
        {
            highscoreListText[i].text = highscoreList.list[i].name + ": " + highscoreList.list[i].score;
        }
        for (int i = 0; i < tokens; i++)
        {
            Instantiate(tokenPrefab, tokenSpawn.position, tokenSpawn.rotation, null);
        }
        tokenUI.SetActive(true);
        newHigh();
    }
    void newHigh()
    {
        string strOutput = JsonUtility.ToJson(highscoreList);
        File.WriteAllText(Application.dataPath + "/Highscores.json", strOutput);
    }
    public void outputJSON()
    {
        string strOutput = JsonUtility.ToJson(highscoreList);
        File.WriteAllText(Application.dataPath + "/Highscores.json", strOutput);
    }
}