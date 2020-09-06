using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int damage;//부딪치면 잃을 체력

    [SerializeField] float force; //튕기는 힘
    [SerializeField] ball_controller theBall;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player")&& theBall.num==0 ) { //충돌체의 Tag가 Player라면
            Debug.Log(damage + "장애물 주의!!");
            other.transform.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 1f);
            //AddExplosionForce : 폭발반경내로 물체를 날려보냄
            //AddExplosionForce(세기, 폭발위치, 폭발반경)
            other.transform.GetComponent<StatusManager>().DecreaseHp(damage);
        }    
    }

}
