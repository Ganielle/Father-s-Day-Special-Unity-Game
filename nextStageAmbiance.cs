using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class nextStageAmbiance : MonoBehaviour
{
    [SerializeField] private SoundManager sfx;

    [Header("Script References")]
    [SerializeField] private PlayButton play;

    [Header("Text mesh pro")]
    [SerializeField] private TextMeshProUGUI quotes;


    private void OnEnable()
    {
        quotes.text = play.nextStageQuote[play.currentIndex];
        sfx.PlayClappingSound();
    }

    private void OnDisable()
    {
        quotes.text = "";
    }
}
