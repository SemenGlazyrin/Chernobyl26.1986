using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManDialog : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject dialogManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            dialogPanel.SetActive(true);
            dialogManager.SetActive(true);
        } 
    }
}
