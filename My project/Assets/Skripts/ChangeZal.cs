using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeZal : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private float time;

    private float timer = 0;
    private bool curStatus = false;
    private bool isChanging = false;

    private void Update()=>
        ChangeImage();

    private void ChangeImage()
    {
        if (!isChanging)
        {
            image.SetActive(curStatus);

            Invoke("GoNextImage", time);
            isChanging = true;
        }
        
    }

    private void GoNextImage()
    {
        if (curStatus)
            curStatus = false;
        else
            curStatus = true;

        isChanging = false;
    }
}
