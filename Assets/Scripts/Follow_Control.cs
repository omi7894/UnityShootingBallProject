using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Control : MonoBehaviour
{
    

    [Header("따라갈 대상")]
    [SerializeField] Transform f_player;

    [Header("따라갈 속도")]
    [Range(0, 1)] //반드시 0과1사이 값
    [SerializeField] float speed;

    Vector3 current_pos; //플레이어와 총 거리 차 기억하는 변수
    void Start()
    {
        current_pos = f_player.position - transform.position; //거리 차 = 플레이어 위치 - 나의 위치
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, f_player.position - current_pos, speed);
    }
}
