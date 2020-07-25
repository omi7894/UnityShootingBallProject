using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Login login;
    [SerializeField] Gun_Control theGun;
    [SerializeField] Text txt_ScoreItem;
    [SerializeField] Text txt_MonsterItem;
    [SerializeField] Text txt_shootingScore;
    [SerializeField] Text txt_TotalScore;
    [SerializeField] Text txt_currentScore;

    [SerializeField] GameObject RankingPanel;

    int shootingScore;

    [SerializeField] Text txt_score;
    [SerializeField] Text txt_id;


    int scoreItem;
    int monsterItem;
    int totalScore;
    int currentScore;

    public string SaveUrl = "omi7894.cafe24.com/Save.php";
    public string RankingUrl = "omi7894.cafe24.com/Ranking.php";
    public string Ranking2Url = "omi7894.cafe24.com/Ranking2.php";

    public void AddShootingScore() { shootingScore += 100; totalScore += 1000; currentScore += 1000; }
    public void AddRouletteScore1() { totalScore += 250; currentScore += 250; }
    public void AddRouletteScore2() { totalScore += 500; currentScore += 500; }
    public void AddRouletteScore3() { totalScore += 1000; currentScore += 1000; }
    public void setZero() {
        shootingScore = 0;
        scoreItem = 0;
        monsterItem = 0;
        totalScore = 0;
        currentScore = 0;
    }



    public void RankingBtn() {

        StartCoroutine(RankingCo());
        StartCoroutine(Ranking2Co());

        RankingPanel.SetActive(true); 
    }
    public void BackBtn() {
        RankingPanel.SetActive(false);
    }
    public void SaveBtn()
    {
        StartCoroutine(SaveCo());
    }
  
    IEnumerator RankingCo()
    {

        WWWForm form = new WWWForm();

        WWW webRequest = new WWW(RankingUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        txt_score.text = "" + webRequest.text;

    }

    IEnumerator Ranking2Co()
    {

        WWWForm form = new WWWForm();

        WWW webRequest = new WWW(Ranking2Url, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        txt_id.text = "" + webRequest.text;

    }
    IEnumerator SaveCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("Input_score", totalScore);
        form.AddField("Input_user", login.GetID());

        WWW webRequest = new WWW(SaveUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);
    }





    void OnTriggerEnter(Collider other)//Trigger : 물리적 연산 없이 충돌 감지 가능. 물체가 그냥 통과함.
    {
        if (other.transform.CompareTag("Item")) {

            Item item = other.GetComponent<Item>();
            if (item.itmeType == ItemType.Score) { // 아이템 타입이 score아이템 이라면
                SoundManager.instance.PlaySE("Item");
                Debug.Log("아이템 획득");
                scoreItem++;
                totalScore += 500;
                currentScore += 500;
                    
               
                txt_ScoreItem.text = " " + scoreItem;
            }
            if (item.itmeType == ItemType.Monster)
            { // 아이템 타입이 monster아이템 이라면
                SoundManager.instance.PlaySE("Item");
                Debug.Log("아이템 획득");
                monsterItem++;
                totalScore += 700;
                currentScore += 700;
                txt_MonsterItem.text = " " + monsterItem;

                theGun.AddBullet();
            }
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        scoreItem = 0;
        monsterItem = 0;
        shootingScore = 0;
        totalScore = 0;
        currentScore = 0;

        txt_ScoreItem.text =" "+ scoreItem;
        txt_MonsterItem.text = " " + monsterItem;
        txt_shootingScore.text = " " + shootingScore;
        txt_TotalScore.text = " " + totalScore;
        txt_currentScore.text = " " + currentScore;

    }
    void Update()
    {
        txt_shootingScore.text = " " + shootingScore;
        txt_TotalScore.text = " " + totalScore;
        txt_currentScore.text = " " + currentScore;
        
    }

}
