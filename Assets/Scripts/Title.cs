using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] public GameObject TitlePannel;

    public void StartBtn()
    {
        TitlePannel.SetActive(false);
        ball_controller.canMove = true;
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}