using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [Header("피격 효과")]
    [SerializeField] GameObject gun_effect; //피격 프리팹 넣어놓을 곳

    [Header("총알 데미지")]
    [SerializeField] int damage;

    [Header("몬스터아이템")]
    [SerializeField] GameObject monsterItem;

  
    
   
    
    void OnCollisionEnter(Collision other) //충돌하는 순간 호출되는 함수
    {
         ContactPoint contactPoint = other.contacts[0];
        //ContacPoint : 접촉면 정보
        //contacts[0] : 충돌객체의 가장 가까운 접촉면 가져오기

        var clone = Instantiate(gun_effect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));
        //접촉면 방향으로 프리팹 생성 시키기

        if (other.transform.CompareTag("Monster")) {
            other.transform.GetComponent<Monster>().Damaged(damage);
            //총알과 몬스터가 부딪친다면 총알의 damage 만큼 몬스터의 체력을 깎는다.
            GameObject clone2 = Instantiate(monsterItem, other.transform.position, Quaternion.Euler(0, 90f, 0));
            Destroy(clone2, 3.0f);
        }
        Destroy(clone, 0.5f); //effect제거
        Destroy(gameObject); //총알제거


    }
 

}
