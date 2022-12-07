using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GoblinController goblinController;
    public Highscore.Player player;
    //public Highscore.Score score;

    public AudioSource GoblinSource;
    public AudioClip[] audioClipArray;

    [Header("Timer Infomation")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerText2;
    public static float timer;
    public static float deleteTimer;
    public float scoretimer = 120f;
    float t;
    public float endRoundTokens;
    public static bool scoreIsSet = false;

    [Header("Score Infomation")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI tokenText;
    public GameObject scoreBoard;

    public bool startRoundTable = false;
    public bool startRoundWall = false;
    public static bool ongoingRound = false;

    public static float playerScoreAmount;

    #region AwakeInstance
    public static GameController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GoblinSource = GameObject.Find("Audio").GetComponent<AudioSource>();
    }
    #endregion

    private void Start()
    {
        scoreText.text = "0";
        timerText.text = "0:00";
        tokenText.text = "0";

        startRoundWall = false;
        startRoundTable = false;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        deleteTimer += Time.deltaTime;

        scoreText.text = playerScoreAmount.ToString();
        scoreText2.text = playerScoreAmount.ToString();

        if (PlayButton.isTable == true && ongoingRound == false)
        {
            startRoundTable = true;
            ongoingRound = true;
            t = scoretimer;
            scoreIsSet = false;
            playerScoreAmount = 0;
        }
        else
            startRoundTable = false;

        if (PlayButton.isWall == true && ongoingRound == false)
        {
            startRoundWall = true;
            ongoingRound = true;
            t = scoretimer;
            scoreIsSet = false;
            playerScoreAmount = 0;
        }
        else
            startRoundWall = false;

        if (deleteTimer >= 1.25f && ongoingRound == true)
        {
            goblinController.DestroyAll();
            deleteTimer = 0;
        }

        if (t > 0 && t < 1)
        {
            scoreBoard.GetComponent<ScoreboardNew>().SetScoreBoard();
            Debug.Log("Score is set");
            PlayButton.isWall = false;
            PlayButton.isTable = false;
        }

        if (t < 0)
        {
            endRoundTokens = Mathf.Round(playerScoreAmount / 35);
            string totalTokens = endRoundTokens.ToString();
            tokenText.text = "You've earned " + totalTokens + " tokens!";

            ongoingRound = false;
            Debug.Log("gameover");

            t = 0;
        }

        if (ongoingRound == true)
        {
            t -= Time.deltaTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            timerText.text = minutes + ":" + seconds;
            timerText2.text = minutes + ":" + seconds;
        }
        if (goblinController != null)
            goblinController.SpawnLoop();
    }


}


