using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private PlayButton play;
    [SerializeField] private SoundManager sfx;

    bool isCorrect;

    private void OnEnable()
    {
        isCorrect = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isCorrect = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isCorrect = false;
    }

    public void onPressButton()
    {
        if (!isCorrect)
        {
            sfx.ClickPlayButton();
            return;
        }

        play.rightAnswer();
    }
}
