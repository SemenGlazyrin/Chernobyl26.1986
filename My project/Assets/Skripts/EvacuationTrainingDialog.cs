using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class EvacuationTrainingDialog : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private List<string> phrases;
    [SerializeField] private List<float> durations;
    [SerializeField] private GameObject levelsList;
    [SerializeField] private GameObject firstButtons;
    [SerializeField] private GameObject secondButtons;

    private int curPhrase = 0;
    private bool isSpeaking = false;
    private bool canContinueTalking = false;

    private int answer = -1;
    private bool turnOnFirstButtons = false;
    private bool turnOnSecondButtons = false;
    [SerializeField] private bool checkAnswer = false;

    private void Update()
    {
        if (curPhrase >= phrases.Count)
        {
            levelsList.SetActive(true);
            text.transform.parent.gameObject.SetActive(false);
            
        }

        if (curPhrase <= 15 || curPhrase >= 21)
        {
            if (!isSpeaking && curPhrase < phrases.Count && (curPhrase == 0 || durations[curPhrase - 1] <= 900))
                Speak();

            if (canContinueTalking)
            {
                canContinueTalking = false;
                isSpeaking = true;

                text.text = "";
            }
        }
        else if (curPhrase <= 21)
        {
            if (turnOnFirstButtons)
                firstButtons.SetActive(true);

            if (checkAnswer)
            {
                checkAnswer = false;
                if (answer == 1)
                {
                    curPhrase = 16;
                    turnOnFirstButtons = false;
                    firstButtons.SetActive(false);

                    canContinueTalking = false;
                    isSpeaking = false;

                    text.text = "";
                    Speak();
                }
                else if (answer == 0)
                {
                    curPhrase = 17;

                    //firstButtons.SetActive(false);

                    canContinueTalking = false;
                    isSpeaking = false;

                    text.text = "";
                    Speak();
                }
                else if (answer == 2)
                {
                    curPhrase = 20;

                    //firstButtons.SetActive(false);

                    canContinueTalking = false;
                    isSpeaking = false;

                    text.text = "";
                    Speak();
                }
                else if (answer == 3)
                {
                    curPhrase = 19;

                    secondButtons.SetActive(false);

                    canContinueTalking = false;
                    isSpeaking = false;

                    text.text = "";
                    Speak();
                }
            }
        }
    }

    private void LoadLevel() =>
        SceneManager.LoadScene(3);

    public void GetAnswer(int ans)
    {
        checkAnswer = true;
        answer = ans;
    }
    public void ChangeCurrentPhrase()
    {
        curPhrase++;
        durations[curPhrase] = 2.5f;

        canContinueTalking = false;
        isSpeaking = false;

        text.text = "";
        Speak();
    }

    private void Speak()
    {
        Debug.Log(phrases[curPhrase]);
        isSpeaking = true;
        text.DOText(phrases[curPhrase], 0.9f);
        if (curPhrase != 16)
            Invoke("ChangeCanContinueTalking", durations[curPhrase]);
        else
        {
            curPhrase = 18;
            Speak();
        }
    }

    private void ChangeCanContinueTalking()
    {
        isSpeaking = false;
        if (answer == -1) 
            curPhrase++;

        if (answer == 1)
        {
            turnOnFirstButtons = false;
            firstButtons.SetActive(false); 
            
            text.text = "";
            curPhrase = 16;
            Speak();
            //curPhrase = 18;
            //Invoke("Speak", 2.5f);
            answer = -2;
        } 
        else if (answer == 0)
        {
            curPhrase -= 2;
            Speak();
            answer = -1;
        }
        else if (answer == 2)
        {
            curPhrase -= 2;
            Speak();
            answer = -1;
        }
        else if (answer == 3)
        {
            Speak();
        }
        

        if (answer == -2 && curPhrase == 18)
            secondButtons.SetActive(true);

        if (curPhrase == 15)
            turnOnFirstButtons = true;

        if (canContinueTalking)
            canContinueTalking = false;
        else
            canContinueTalking = true;

        if (curPhrase == 19)
            Invoke("LoadLevel", 5f);
    }
}
