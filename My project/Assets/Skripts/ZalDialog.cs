using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ZalDialog : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private List<string> phrases;
    [SerializeField] private List<float> durations;
    [SerializeField] private GameObject levelsList;
    [SerializeField] private bool isZal = false;

    private int curPhrase = 0;

    private bool isSpeaking = true;
    private bool canContinueTalking = false;

    private void Update()
    {
        if (isSpeaking && curPhrase < phrases.Count)
            Speak();

        if (curPhrase >= phrases.Count)
        {
            levelsList.SetActive(true);
            if (isZal) 
                text.transform.parent.gameObject.SetActive(false);
        }  

        if (canContinueTalking)
        {
            canContinueTalking = false;
            isSpeaking = true;
            curPhrase++;
            text.text = "";
        } 
    }

    private void Speak()
    {
        isSpeaking = false;
        text.DOText(phrases[curPhrase], 0.9f);
        Invoke("ChangeCanContinueTalking", durations[curPhrase]);
    }

    private void ChangeCanContinueTalking()
    {
        if (canContinueTalking)
            canContinueTalking = false;
        else
            canContinueTalking = true;
    }
}
