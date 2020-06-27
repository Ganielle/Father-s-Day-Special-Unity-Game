using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using System;

public class PlayButton : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] private GameObject[] questions;
    [SerializeField] private GameObject mainMenu, nextStage, greetingStage, endStage;

    [Header("Hints")]
    [TextArea][SerializeField] private String[] hints;
    [TextArea] public String[] nextStageQuote;

    [Header("Values")]
    [SerializeField] private int index = 0;
    public int currentIndex = 0;
    [SerializeField] private float delay;
    public int videoIndex;
    public int pizzaCount = 0;

    [Header("Game Objects")]
    [SerializeField] private GameObject about;
    [SerializeField] private GameObject mainmenu;

    [Header("Text Mesh Pro")]
    [SerializeField] private TextMeshProUGUI pizzaCountTMPro;
    [SerializeField] private TextMeshProUGUI hintsTMPro;

    [Header("Script Reference")]
    [SerializeField] private SoundManager sfx;
    [SerializeField] private KeyboardButtons kbButtons;

    public void playButton()
    {
        currentIndex = index;

        if (nextStage.activeSelf)
            nextStage.SetActive(false);

        if (greetingStage.activeSelf)
            greetingStage.SetActive(false);

        if(index == 0)
        {
            mainMenu.SetActive(false);
            questions[index].SetActive(true);
        }
        if(index > 0)
        {
            questions[index - 1].SetActive(false);
            questions[index].SetActive(true);
        }
        index++;
    }

    public void showMainMenu()
    {
        sfx.ClickPlayButton();
        about.SetActive(false);
        mainmenu.SetActive(true);
    }

    public void showAbout()
    {
        sfx.ClickPlayButton();
        mainmenu.SetActive(false);
        about.SetActive(true);
    }

    public void ShowHints() 
    {
        sfx.ClickPlayButton();
        hintsTMPro.text = hints[currentIndex];
    }

    public void increasePizzaCount()
    {
        pizzaCount++;
        pizzaCountTMPro.text = Convert.ToString(pizzaCount);
    }

    public void decreasePizzaCount()
    {
        if (pizzaCount == 0)
            return;

        pizzaCount--;
        pizzaCountTMPro.text = Convert.ToString(pizzaCount);
    }

    public void answerCount()
    {
        if (pizzaCount == 11)
            rightAnswer();
        else
            sfx.PlayWrongAnswer();
    }

    public void placeCount()
    {
        if (kbButtons.textArea.text != "2")
        {
            sfx.PlayWrongAnswer();
            kbButtons.textArea.text = "";
        }
        else if (kbButtons.textArea.text == "2")
            rightAnswer();
    }

    public void alphabetCount()
    {
        if (kbButtons.alphabetTextArea.text != "6")
        {
            sfx.PlayWrongAnswer();
            kbButtons.alphabetTextArea.text = "";
        }
        else if (kbButtons.alphabetTextArea.text == "6")
            rightAnswer();
    }

    public void rightAnswer()
    {
        StartCoroutine(playRightAnswer());
    }

     IEnumerator playRightAnswer()
    {
        sfx.PlayRightAnswer();

        yield return new WaitForSeconds(delay);
        questions[index - 1].SetActive(false);

        if (index == questions.Length)
        {
            questions[index - 1].SetActive(false);
            sfx.ambienceSource.clip = null;
            endStage.SetActive(true);
        }

        if (isGreetings(index) && index != questions.Length)
            greetingStage.SetActive(true);
        else if(!isGreetings(index) && index != questions.Length)
            nextStage.SetActive(true);

        hintsTMPro.text = "";
    }

    private bool isGreetings(int num)
    {
        return num % 3 == 0;
    }
}
