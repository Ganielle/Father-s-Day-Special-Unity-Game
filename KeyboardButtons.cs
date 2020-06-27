using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardButtons : MonoBehaviour
{
    [Header("TextArea")]
    public TMP_InputField textArea;
    public TMP_InputField alphabetTextArea;

    public void TextButton(string text) => textArea.text += text;

    public void AlphabetTextButton(string text) => alphabetTextArea.text += text;

    public void deleteText() => textArea.text = "";

    public void aplhabetDeleteText() => alphabetTextArea.text = "";
}
