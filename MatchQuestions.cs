using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchQuestions : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject[] disableMatches;
    [SerializeField] private List<GameObject> matches;

    [Header("Script Reference")]
    [SerializeField] private PlayButton play;
    [SerializeField] private SoundManager sfx;

    public int matchCount;
    public int matchRightAnswerCount;


    private void Update()
    {
        CheckCountMatches();
    }

    public void CheckMatches()
    {
        if (matchRightAnswerCount != 6)
            return;

        play.rightAnswer();
    }

    private void CheckCountMatches()
    {
        if (matchCount != 6 || matchRightAnswerCount == 6)
            return;

        foreach(GameObject go in matches)
        {
            go.SetActive(true);
        }
        sfx.PlayWrongAnswer();
        matchCount = 0;
        matchRightAnswerCount = 0;
    }
}
