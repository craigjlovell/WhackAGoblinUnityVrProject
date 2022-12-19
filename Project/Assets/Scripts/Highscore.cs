//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.UI;
//using TMPro;
//using System.IO;
//using System.Linq;

//public class Highscore : MonoBehaviour
//{
//    [System.Serializable]
//    public class Player
//    {
//        public string playerName;
//    }

//    [System.Serializable]
//    public class Score
//    {
//        public int playerScore;
//    }

//    [System.Serializable]
//    public class HighscoreList
//    {
//        public List<Player> nameList;
//        public List<Score> scoreList;
//    }

//    public TextAsset json;

//    public Player player = new Player();
//    public Score score = new Score();

//    public HighscoreList highscoreList = new HighscoreList();

//    //[SerializeField] private TextMeshProUGUI entryHighscoreText;
//    [SerializeField] private TextMeshProUGUI entryScoreText;
//    [SerializeField] private TMP_InputField inputPlayerName;

//    public List<TextMeshProUGUI> highscoreListText = new List<TextMeshProUGUI>();
//    public List<TextMeshProUGUI> nameListText = new List<TextMeshProUGUI>();

//    public TextMeshProUGUI finalScore;

//    // Start is called before the first frame update
//    private void Start()
//    {
//        highscoreList = JsonUtility.FromJson<HighscoreList>(json.text);
//        //entryHighscoreText.text = "High Score: \n" + highscoreList.scoreList[0].playerScore.ToString();

//    }

//    // Update is called once per frame
//    private void Update()
//    {
//        //entryScoreText.text = "Score: \n" + score.playerScore;        
//        //finalScore.text = "Score: " + score.playerScore;

//        if(Keyboard.current.pKey.wasPressedThisFrame)
//        {
//            highscoreList.scoreList.Clear();
//            highscoreList.nameList.Clear();
//        }
//    }

//    public void SetName()
//    {
//        player.playerName = "Name: \n" + inputPlayerName.text;
//        SortScore();
//    }

//    public void SortScore()
//    {
//        highscoreList.scoreList.Add(score);
//        highscoreList.nameList.Add(player);
//        highscoreList.scoreList = highscoreList.scoreList.OrderBy(x => x.playerScore).ToList();
//        highscoreList.scoreList.Reverse();
//        if (highscoreList.scoreList.Count > 5 && highscoreList.nameList.Count > 5)
//        {
//            highscoreList.scoreList.RemoveAt(5);
//            highscoreList.nameList.RemoveAt(5);
//        }

//        NewHighScore();

//        for (int i = 0; i < 5; i++)
//        {
//            highscoreListText[i].text += highscoreList.scoreList[i].playerScore;
//            nameListText[i].text += highscoreList.nameList[i].playerName;
//        }
//    }

//    void NewHighScore()
//    {
//        string strOutput = JsonUtility.ToJson(highscoreList);
//        File.WriteAllText(Application.dataPath + "/SaveData.json", strOutput);
//    }

//    public void outputJSON()
//    {
//        string strOutput = JsonUtility.ToJson(highscoreList);
//        File.WriteAllText(Application.dataPath + "/SaveData.json", strOutput);
//    }

//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System.IO;
using System.Linq;
public class Highscore : MonoBehaviour
{
    public TextAsset json;
    public Player player = new Player();
    public HighscoreList highscoreList = new HighscoreList();
    //[SerializeField] private TextMeshProUGUI entryHighscoreText;
    //[SerializeField] private TextMeshProUGUI entryScoreText;
    public List<TextMeshProUGUI> highscoreListText = new List<TextMeshProUGUI>();
    //public TextMeshProUGUI finalScore;
    public TMP_InputField inputPlayerName;
    public GameController gameController;

    // Start is called before the first frame update
    private void Start()
    {
        highscoreList = JsonUtility.FromJson<HighscoreList>(json.text);

        //entryHighscoreText.text = "High Score: \n" + highscoreList.scoreList[0].playerScore.ToString();
    }
    // Update is called once per frame
    private void Update()
    {
        //entryScoreText.text = "Score:\n" + player.playerScore;
        //finalScore.text = "Score:" + player.playerScore;

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            highscoreList.scoreList.Clear();            
        }
    }
    public void SetName()
    {
        player.playerName = inputPlayerName.text;
        gameController.name = inputPlayerName.text;
        SortScore();
    }
    public void SortScore()
    {
        highscoreList.scoreList.Add(player);
        highscoreList.scoreList = highscoreList.scoreList.OrderBy(x => x.playerScore).ToList();
        highscoreList.scoreList.Reverse();
        if (highscoreList.scoreList.Count > 5)
            highscoreList.scoreList.RemoveAt(5);
        NewHighScore();
        for (int i = 0; i < 5; i++)
        {
            highscoreListText[i].text = highscoreList.scoreList[i].playerName + ": " + highscoreList.scoreList[i].playerScore;
        }
    }
    void NewHighScore()
    {
        string strOutput = JsonUtility.ToJson(highscoreList);
        File.WriteAllText(Application.dataPath + "/SaveData.json", strOutput);
    }
    public void outputJSON()
    {
        string strOutput = JsonUtility.ToJson(highscoreList);
        File.WriteAllText(Application.dataPath + "/SaveData.json", strOutput);
    }
}

[System.Serializable]
public class Player
{
    public string playerName;
    public int playerScore;
}

[System.Serializable]
public class HighscoreList
{
    public List<Player> scoreList;
}


