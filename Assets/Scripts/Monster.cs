using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
public class Monster : MonoBehaviour
{
    [SerializeField] float verticalDistance;//수직움직임
    [SerializeField] float horizontalDistance;//수평움직임
    
    [Range(0,1)]
    [SerializeField] float moveSpeed;//움직일 스피드

    [SerializeField] int hp; //몬스터의 체력(총 여러번 맞고 죽도록)
    [SerializeField] int damage;
    [SerializeField] GameObject go_EffectPrefab; //몬스터 터질때 나오는 effect
    [SerializeField] PickUpItem thePick;
    [SerializeField] ball_controller theBall;

    Vector3 endPos1;
    Vector3 endPos2;
    Vector3 currentDestination;

    void Start()
    {
        Vector3 originPos = transform.position;
        endPos1.Set(originPos.x, originPos.y + verticalDistance, originPos.z + horizontalDistance);
        endPos2.Set(originPos.x, originPos.y - verticalDistance, originPos.z - horizontalDistance);
        currentDestination = endPos1;
    }

    void Update()
    {
        if ((transform.position - endPos1).sqrMagnitude <= 0.1f)
        {
            currentDestination = endPos2;
        }
        else if ((transform.position - endPos2).sqrMagnitude <= 0.1f) {
            currentDestination = endPos1;
        }
        transform.position = Vector3.Lerp(transform.position, currentDestination, moveSpeed);    
    }

    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player") && theBall.num==0) {

            other.transform.GetComponent<StatusManager>().DecreaseHp(damage);
            Explosion();
        }
        if (other.transform.CompareTag("Player") && theBall.num != 0)
        {
            thePick.AddShootingScore();
            Explosion();
        }
        if (other.transform.CompareTag("Bullet"))
        {
            thePick.AddShootingScore();
        }
    }
    

    public void Damaged(int _num) {
        hp -= _num;
        if (hp <= 0) { Explosion(); }
    }

     void Explosion(){

        GameObject clone = Instantiate(go_EffectPrefab, transform.position, Quaternion.identity);
        Destroy(clone, 2f);
        Destroy(gameObject);
    }
    
  



}
