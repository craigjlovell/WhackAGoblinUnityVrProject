using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBash : MonoBehaviour
{
    public GoblinController goblinManager;
    public GameController gameController;

    public Vector3 startPosition;
    public GameObject spawnPointPos;
    public Vector3 spawnPoint;
    public Quaternion startRotation;

    public bool isHolding = false;
    BoxCollider boxCollider;
    Rigidbody hammor;

    private void Start()
    {
        goblinManager = GameObject.Find("GameController2").GetComponent<GoblinController>();
        spawnPoint = spawnPointPos.transform.localPosition;
        startPosition = transform.localPosition;
        startRotation = transform.rotation;
        boxCollider = transform.GetComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        hammor = transform.GetComponent<Rigidbody>();
    }

    public void HoldHammor()
    {
        boxCollider.isTrigger = true;
        isHolding = true;
    }

    public void Throw()
    {
        isHolding = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RedGoblin") || other.CompareTag("GreenGoblin") || other.CompareTag("BlueGoblin"))
        {
            GameObject goblin = other.gameObject;
            GameController.instance.GoblinSource.clip = GameController.instance.audioClipArray[Random.Range(0, GameController.instance.audioClipArray.Length)];
            GameController.instance.GoblinSource.PlayOneShot(GameController.instance.GoblinSource.clip);
            goblinManager.GobboDestroy(goblin);

            if (other.CompareTag("BlueGoblin"))
                gameController.scoreTotal += goblinManager.goblinTypes[0].pointValue;
                //gameController.player.playerScore += goblinManager.goblinTypes[0].pointValue;
            else if (other.CompareTag("GreenGoblin"))
                gameController.scoreTotal += goblinManager.goblinTypes[1].pointValue;
                //gameController.player.playerScore += goblinManager.goblinTypes[1].pointValue;
            else if (other.CompareTag("RedGoblin"))
                gameController.scoreTotal += goblinManager.goblinTypes[2].pointValue;

            gameController.player.playerScore = gameController.scoreTotal;
        }

        if (other.CompareTag("Ground"))
        {
            Respawn();
        }
    }

    private void Update()
    {
        
    }

    void Respawn()
    {
        hammor.velocity = Vector3.zero;
        hammor.angularVelocity = Vector3.zero;

        boxCollider.isTrigger = false;
        transform.localPosition = spawnPoint;
        transform.rotation = startRotation;
    }
}
