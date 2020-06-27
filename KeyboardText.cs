﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardText : MonoBehaviour
{
    [Header("Text Value")]
    [SerializeField] private string text;

    [Header("Script Reference")]
    [SerializeField] private KeyboardButtons kbButtons;

    public void pressKBButton() => kbButtons.TextButton(text);

    public void alphabetPressKBButton()=> kbButtons.AlphabetTextButton(text);
}
