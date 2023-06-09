using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiaryMenu : MonoBehaviour
{
    public static bool DiaryMenuIsOpen = false;
    public GameObject diaryMenuUI;
    public GameObject diaryButton;

    // Update is called once per frame
    void Update()
    {
    }
    public void DiaryButtonPressed()
    {
        if (DiaryMenuIsOpen)
        {
            ReturnGame();
        }else
        {
            DiaryOpen();
        }
    }
    public void ReturnGame()
    {
        diaryMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Interação com o Menu");
        DiaryMenuIsOpen = false;
    }
    void DiaryOpen()
    {
        diaryMenuUI.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Interação com o Menu");
        DiaryMenuIsOpen = true;
    }
}
