using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GoblinController goblinController;
    public Highscore highscore;
    public Player player;

    public string name;
    //public Highscore.Score score;
    
    public AudioSource GoblinSource;
    public AudioClip[] audioClipArray;

    [Header("Timer Infomation")]
    public TextMeshProUGUI timerText;
    public static float timer;
    public static float deleteTimer;
    public float scoretimer = 120f;
    float t;
    public float endRoundTokens;

    [Header("Score Infomation")]
    public int scoreTotal;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI tokenText;

    public bool startRoundTable = false;
    public bool startRoundWall = false;
    public bool ongoingRound = false;        

    #region AwakeInstance
    public static GameController instance;
    private void Awake()
    {
        if(instance == null)
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
        t = scoretimer;
        
        scoreText.text = "0";
        timerText.text = "0:00";

        startRoundWall = false;
        startRoundTable = false;        
    }

    public void Update()
    {        
        timer += Time.deltaTime;
        deleteTimer += Time.deltaTime;
        player.playerName = name;

        if (PlayButton.isTable == true)
            startRoundTable = true;
        else
            startRoundTable =false;

        if (PlayButton.isWall == true)
            startRoundWall = true;
        else
            startRoundWall = false;

        if (deleteTimer >= 1.25f && ongoingRound == true)
        {
            goblinController.DestroyAll();
            deleteTimer = 0;
        }

        if (t <= 0)
        {
            t = 0;
            endRoundTokens = player.playerScore / 35;
            string totalTokens = endRoundTokens.ToString();
            tokenText.text = "You've earned" + totalTokens + "tokens!";

            startRoundWall = false;
            startRoundTable = false;

            PlayButton.isTable = false;
            PlayButton.isWall = false;

            ongoingRound = false;
            Debug.Log("gameover");
            goblinController.DestroyAll();            
        }
        
        if (ongoingRound == true)
        {
            t -= Time.deltaTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            timerText.text = minutes + ":" + seconds;
        }

        if(goblinController != null)
            goblinController.SpawnLoop();

        scoreText.text = scoreTotal.ToString();
    }    
}


