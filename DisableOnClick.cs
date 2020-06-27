using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnClick : MonoBehaviour
{
    [SerializeField] private MatchQuestions match;
    [SerializeField] private SoundManager sfx;

    public void disableOnClick()
    {
        sfx.ClickPlayButton();
        gameObject.SetActive(false);
        match.matchCount++;
        match.CheckMatches();
    }

    public void disableRightMatches()
    {
        sfx.ClickPlayButton();
        gameObject.SetActive(false);
        match.matchRightAnswerCount++;
        match.matchCount++;
        match.CheckMatches();
    }
}
