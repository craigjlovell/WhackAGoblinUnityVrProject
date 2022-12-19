using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.1f;

    private bool a_isPressed;
    private Vector3 a_startPos;
    private ConfigurableJoint a_joint;

    public UnityEvent onPressed, onReleased;

    public static bool isTable = false;
    public static bool isWall = false;

    #region AwakeInstance
    public static PlayButton instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;           
        }
        
    }
    #endregion

    void Start()
    {
        a_startPos = transform.localPosition;
        a_joint = GetComponent<ConfigurableJoint>();
        isTable = false;
        isWall = false;
    }

    public void GameStartTable()
    {
        isTable = true;
    }

    public void GameStartWall()
    {
        isWall = true;
    }

    private void Update()
    {
        if (!a_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (a_isPressed && GetValue() - threshold <= 0)
            Released();

        if (Keyboard.current.cKey.wasPressedThisFrame)
            GameStartTable();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(a:a_startPos, b:transform.localPosition) / a_joint.linearLimit.limit;

        if(Mathf.Abs(value) < deadZone)        
            value = 0;

        return Mathf.Clamp(value, min:-1f, max:1f);
    }

    private void Pressed()
    {
        a_isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        a_isPressed = false;
        onReleased.Invoke();
        Debug.Log("Pressed");
    }
}
