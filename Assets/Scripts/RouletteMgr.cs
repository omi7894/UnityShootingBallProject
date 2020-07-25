using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class RouletteMgr : MonoBehaviour
{

    [SerializeField] GameObject RouletteUI;
    [SerializeField] Rigidbody playerRigid;

    [SerializeField] StageManager SM;
    [SerializeField] PickUpItem thePick;

    [SerializeField] Button start;
    [SerializeField] Button next;

    public GameObject RoulettePlate;
    public GameObject RoulettePanel;
    public Transform Needle;

    public Sprite[] SkillSprite;
    public Image[] DisplayItemSlot;

    List<int> StartList = new List<int>();
    List<int> ResultIndexList = new List<int>();
    int ItemCnt = 8;

    public void ShowRouletteUI() {

        ball_controller.canMove = false;
        playerRigid.isKinematic = true;
        RouletteUI.SetActive(true);
    }

    private void Start()
    {
        next.gameObject.SetActive(false);
        start.gameObject.SetActive(true);
    }

    /*
    void Start()
    {
        for (int i = 0; i < ItemCnt; i++)
        {
            StartList.Add(i);
        }

        for (int i = 0; i < ItemCnt; i++)
        {
            int randomIndex = Random.Range(0, StartList.Count);
            ResultIndexList.Add(StartList[randomIndex]);
            DisplayItemSlot[i].sprite = SkillSprite[StartList[randomIndex]];
            StartList.RemoveAt(randomIndex);
        }

       
    }
    */

    public void RstartBTN()
    {
        for (int i = 0; i < ItemCnt; i++)
        {
            StartList.Add(i);
        }

        for (int i = 0; i < ItemCnt; i++)
        {
            int randomIndex = Random.Range(0, StartList.Count);
            ResultIndexList.Add(StartList[randomIndex]);
            DisplayItemSlot[i].sprite = SkillSprite[StartList[randomIndex]];
            StartList.RemoveAt(randomIndex);
        }
        StartCoroutine(StartRoulette());
    }
    public void RnextBTN() {

        RouletteUI.SetActive(false);
        SM.ShowClearUI();
        start.gameObject.SetActive(true);
        next.gameObject.SetActive(false);
        
    }
    IEnumerator StartRoulette()
    {
        start.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        float randomSpd = Random.Range(1.0f, 5.0f);
        float rotateSpeed = 100f * randomSpd;

        while (true)
        {
            yield return null;
            if (rotateSpeed <= 0.01f) break;

            rotateSpeed = Mathf.Lerp(rotateSpeed, 0, Time.deltaTime * 2f);
            RoulettePlate.transform.Rotate(0, 0, rotateSpeed);
        }
        yield return new WaitForSeconds(1f);
        Result();

        yield return new WaitForSeconds(1f);
    }

    void Result()
    {
        int closetIndex = -1;
        float closetDis = 500f;
        float currentDis = 0f;

        for (int i = 0; i < ItemCnt; i++)
        {
            currentDis = Vector2.Distance(DisplayItemSlot[i].transform.position, Needle.position);
            if (closetDis > currentDis)
            {
                closetDis = currentDis;
                closetIndex = i;
            }
        }
        Debug.Log(" closetIndex : " + closetIndex);
        if (closetIndex == -1)
        {
            Debug.Log("Something is wrong!");
        }
        DisplayItemSlot[ItemCnt].sprite = DisplayItemSlot[closetIndex].sprite;

        Debug.Log(" LV UP Index : " + ResultIndexList[closetIndex]);

        if (closetIndex == 0 || closetIndex == 3 || closetIndex == 6) {
            thePick.AddRouletteScore1();
        }
        if (closetIndex == 1 || closetIndex == 4 || closetIndex == 7) {
            thePick.AddRouletteScore2();
        }
        if (closetIndex == 2 || closetIndex == 5) {
            thePick.AddRouletteScore3();
        }
        next.gameObject.SetActive(true);

    }
}
