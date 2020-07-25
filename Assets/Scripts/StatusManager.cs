using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StatusManager : MonoBehaviour
{
    [SerializeField] StageManager SM;
    [SerializeField] int maxHp;
    [SerializeField] int currentHp;

    [SerializeField] Text textHP;

    [SerializeField] float blinkSpeed; //깜빡임 속도
    [SerializeField] int blinkCount;   //깜빡임 횟수

    [SerializeField] MeshRenderer mesh_PlayerGraphics; //깜빡이는 대상
    //MeshRenderer : 물체의 점,선,면
    public void setMaxHP() {
        currentHp = maxHp;
    }

    public void DecreaseHp(int _num) {
        SoundManager.instance.PlaySE("Obstacle");
        StartCoroutine(BlinkCoroutine());
        currentHp--;
        if (currentHp == 0)
        {
            SM.ShowGameOverUI();
        }
        else
        {
            textHP.text = "x " + currentHp;
        }
    }

    IEnumerator BlinkCoroutine() {
        for (int i = 0; i < blinkCount * 2; i++) {//사라졌다 나타나도록 짝수 횟수로 맞춰줘야 함.
            mesh_PlayerGraphics.enabled = !mesh_PlayerGraphics.enabled;//Mesh 활성화 비활성화 반복
            yield return new WaitForSeconds(blinkSpeed);//blinkSpeed시간만큼 대기
        }
    }
    //코루틴 : 병렬처리 기법. 일정시간동안의 대기 기능이 가능하다.

    // Start is called before the first frame update
    void Start()
    {
        textHP.text = "x " + currentHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
