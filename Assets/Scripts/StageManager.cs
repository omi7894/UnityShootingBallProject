using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    //[SerializeField] Text scorItem;
    //[SerializeField] Text monsterItem;
    [SerializeField] GameObject stageUI;
    [SerializeField] GameObject GameOverUI;
    // [SerializeField] PickUpItem pui;

    [SerializeField] GameObject[] stages;
    int currentStage = 0;




    [SerializeField] Rigidbody playerRigid;

    [SerializeField] Transform playerOriginPos;
    public void ShowClearUI() {
        ball_controller.canMove = false;
        playerRigid.isKinematic = true;
        stageUI.SetActive(true);
    }
    public void ShowGameOverUI()
    {
        ball_controller.canMove = false;
        playerRigid.isKinematic = true;
        GameOverUI.SetActive(true);
    }

    public void NextBtn() {
        if (currentStage < stages.Length - 1)
        {
            ball_controller.canMove = true;
            playerRigid.isKinematic = false;
            playerRigid.gameObject.transform.position = playerOriginPos.position;
            stages[currentStage++].SetActive(false);
            stages[currentStage].SetActive(true);
            stageUI.SetActive(false);
        }
        else {
            Debug.Log("모든 스테이지 클리어");
        }
    }
    public void ExitBtn() {
        Application.Quit();
        Debug.Log("게임 종료");
    }
}
