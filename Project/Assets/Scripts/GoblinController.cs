using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoblinController : MonoBehaviour
{
    public GoblinController goblinManager;
    public GameController gameController;




    [Header("SpawnPoint Infomation")]
    public Transform spawnPointsTable;
    public Transform spawnPointsWall;
    [SerializeField] public List<GameObject> spawnerListTable = new List<GameObject>();
    [SerializeField] public List<GameObject> spawnerListWall = new List<GameObject>();

    [Header("Goblin Infomation")]
    public int maxSpawnAmount = 2;
    public int spawnCount = 0;
    public float totalGoblinValue = 0;
    [SerializeField] public List<GameObject> goblinList = new List<GameObject>();
    [SerializeField] public List<float> goblinValues = new List<float>();
    [SerializeField] public List<ScriptableGoblin> goblinTypes = new List<ScriptableGoblin>();
    [SerializeField] public List<Animator> animators = new List<Animator>();

    // Start is called before the first frame update
    private void Start()
    {
        goblinManager = GameObject.Find("GameController2").GetComponent<GoblinController>();
        goblinValues.Add(10);
        goblinValues.Add(20);
        goblinValues.Add(45);

        foreach (Transform table in spawnPointsTable)
        {
            spawnerListTable.Add(table.transform.gameObject);
        }

        foreach (Transform wall in spawnPointsWall)
        {
            spawnerListWall.Add(wall.transform.gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (totalGoblinValue >= 1500 && totalGoblinValue < 2800)
        {
            spawnCount = 1;
        }
        else if (totalGoblinValue >= 2800)
        {
            spawnCount = 2;
        }
    }

    // Creates the loop to spawn goblins always under a specific amount on the screen at one time
    public void SpawnLoop()
    {
        if (goblinList.Count < maxSpawnAmount)
        {
            if (PlayButton.isTable == true || PlayButton.isWall == true)
            {
                GameController.instance.ongoingRound = true;
                GoblinSpawn();
            }
        }
    }

    public void GoblinSpawn()
    {        
        for (int i = 0; i < maxSpawnAmount; i++)
        {
            Vector3 randomPos = new Vector3(0, 0, 0);
            if (spawnerListTable.Count > 0 && PlayButton.isTable == true)
            {
                int RandomNumber = Random.Range(0, 3 - spawnCount);
                // Creates the goblin
                GameObject CurrentGobbo = Instantiate(goblinTypes[RandomNumber].goblin, randomPos, Quaternion.identity, spawnerListTable[Random.Range(0, spawnerListTable.Count)].transform);
                CurrentGobbo.transform.localPosition = new Vector3(0, -0.35f, 0);
                CurrentGobbo.transform.localRotation = new Quaternion(0, 180, 0,0);
                float GoblinValue = goblinValues[RandomNumber];
                CurrentGobbo.SetActive(true);
                goblinList.Add(CurrentGobbo);
                totalGoblinValue += GoblinValue;
            }
            else if (spawnerListWall.Count > 0 && PlayButton.isWall == true)
            {
                int RandomNumber = Random.Range(0, 3 - spawnCount);
                GameObject CurrentGobbo = Instantiate(goblinTypes[RandomNumber].goblin, randomPos, Quaternion.identity, spawnerListWall[Random.Range(0, spawnerListWall.Count)].transform);
                CurrentGobbo.transform.localPosition = new Vector3(0, 0, 0);
                CurrentGobbo.transform.localRotation = new Quaternion(0, 180, 0, 0);
                float GoblinValue = goblinValues[RandomNumber];
                CurrentGobbo.SetActive(true);
                goblinList.Add(CurrentGobbo);
                totalGoblinValue += GoblinValue;
            }
        }
    }
    public void GobboDestroy(GameObject a_gobbo)
    {

        if (PlayButton.isTable == true)
        {
            goblinList.Remove(a_gobbo);
            Destroy(a_gobbo);
        }
        else if (PlayButton.isWall == true)
        {
            goblinList.Remove(a_gobbo);
            Destroy(a_gobbo);
        }
        else
        {
            goblinList.Remove(a_gobbo);
            Destroy(a_gobbo);
        }
    }

    public void DestroyAll()
    {
        foreach (GameObject gobbo in goblinList)
        {
            if (gobbo != null)
            {
                GobboDestroy(gobbo);
            }
        }

        maxSpawnAmount = Random.Range(0, 4);
    }
}
