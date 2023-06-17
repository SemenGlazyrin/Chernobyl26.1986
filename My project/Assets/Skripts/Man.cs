using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] private EvacuationTrainingDialog evacuationTrainingDialog;
    private bool firstCollision = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && firstCollision)
        {
            evacuationTrainingDialog.ChangeCurrentPhrase();
            firstCollision = false;
        }
    }
}
