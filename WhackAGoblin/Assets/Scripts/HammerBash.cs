using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBash : MonoBehaviour
{
    GoblinController goblinManager;

    public Vector3 startPosition;
    public GameObject spawnPointPos;
    public Vector3 spawnPoint;
    public Quaternion startRotation;

    public bool isHolding = false;
    BoxCollider boxCollider;
    Rigidbody hammor;

    private void Start()
    {
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
        if (other.CompareTag("RedGoblin") || other.CompareTag("GreenGoblin") || other.CompareTag("BlueGoblin"))
        {
            GameObject goblin = other.gameObject;
            GameController.instance.GoblinSource.clip = GameController.instance.audioClipArray[Random.Range(0, GameController.instance.audioClipArray.Length)];
            GameController.instance.GoblinSource.PlayOneShot(GameController.instance.GoblinSource.clip);


            if (other.CompareTag("RedGoblin"))
                GameController.playerScoreAmount += 45;
            else if (other.CompareTag("BlueGoblin"))
                GameController.playerScoreAmount += 20;
            else if (other.CompareTag("GreenGoblin"))
                GameController.playerScoreAmount += 10;

            goblinManager.GobboDestroy(goblin);
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
