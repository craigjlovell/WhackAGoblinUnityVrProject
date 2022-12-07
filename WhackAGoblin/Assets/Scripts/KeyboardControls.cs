using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class KeyboardControls : MonoBehaviour
{
    public TMP_InputField inputText;
    public GameController gameController;

    public void SetText(string letter)
    {
        inputText.text += letter;        
    }

    public void DeleteChar()
    {
        inputText.text = inputText.text.Remove(inputText.text.Length - 1,1);
    }

    public void SaveName()
    {
        inputText.text = gameController.name;
    }
}
