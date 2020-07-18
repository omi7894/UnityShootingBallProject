using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [Header("따라갈 플레이어")]
    [SerializeField] Transform followPlayer;

    [Header("따라갈 속도")]
    [Range(0, 1f)] [SerializeField] float chaseSpeed;

    float cameraXpos; //카메라의 x좌표 저장. x좌표는 유지시켜야 하기 때문에
  
    void Start()
    {
        cameraXpos = transform.position.x;
    }

    
    void Update()
    {
        Vector3 movePos = Vector3.Lerp(transform.position, followPlayer.position, chaseSpeed); 
        transform.position = new Vector3(cameraXpos, movePos.y, movePos.z);
        //Lerp(따라가는 물체 위치, 따라가는 목표물 위치, 보간비율)
    }
}
