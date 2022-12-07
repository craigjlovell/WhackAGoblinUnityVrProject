using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gobbo
{
    GREEN,
    BLUE,
    RED
}

[CreateAssetMenu(fileName = "Goblin", menuName = "ScriptableObjects/Goblin", order = 1)]

public class ScriptableGoblin : ScriptableObject
{
    [SerializeField] private Gobbo colour;
    public float speed;
    public int pointValue;
    public GameObject goblin;

}
