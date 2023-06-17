using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject[] dialogWindows;
    [SerializeField] private Text[] dialog;
    [SerializeField] private string[] phrases;

    private PlayerMovement playerMovement;

    private bool startDialog = false;

    private void Update()
    {
        if (startDialog)
            Dialog(0);
    }

    private void Dialog(int i)
    {
        if (i < phrases.Length)
        {
            startDialog = false;

            dialogWindows[i].SetActive(true);
            dialog[i].DOText(phrases[i], 0.9f);

            GoNextPhrase(3000, i);
        }
    }

    private void GoNextPhrase(float time, int i)
    {
        var timer = 0.0;

        while (timer < time)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
            
        if (timer >= time)
        {
            dialogWindows[i].SetActive(false);
            Dialog(i + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerMovement = collision.GetComponent<PlayerMovement>();
            playerMovement.enabled = false;
            startDialog = true;
            Debug.Log("2324");
        }
    }
}
