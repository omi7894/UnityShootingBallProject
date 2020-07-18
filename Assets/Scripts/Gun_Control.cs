using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Control : MonoBehaviour
{
    [Header("현재 장착된 총")]
    [SerializeField] Gun currentGun;

    float currentFireRate;


    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = 0; //맨처음엔 그냥 발사가능
    }

    // Update is called once per frame
    void Update()
    {
        FireRateCalc();
        TryFire();
        LockOnMouse();
    }
    void FireRateCalc() {
        if (currentFireRate > 0) {
            currentFireRate -= Time.deltaTime;
        }
    
    }
    //currentFireRate 1초에 1씩 감소
    void TryFire() {
        if (Input.GetButton("Fire1")) {//GetButton : 버튼클릭 감지, Fire1 : 마우스 왼쪽 버튼

            if (currentFireRate <= 0)
            {
                currentFireRate = currentGun.fireRate;
                Fire();
            }
        }
    
    }
    //currentFireRate<=0이 되면 발사가능. 이후 다시 currentFireRate를 FireRate로 리셋

    void Fire() {

        Debug.Log("총알 발사");
        SoundManager.instance.PlaySE("Shoot");
        currentGun.ps_gunflash.Play();
        var clone = Instantiate(currentGun.bullet_prefab, currentGun.ps_gunflash.transform.position, Quaternion.identity);
        //var : 변수타입 모를때. GameObject라고 해도 됨.
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * currentGun.speed);
    }
    void LockOnMouse() {//마우스 조준

        Vector3 cameraPos = Camera.main.transform.position; //카메라 위치 기억시키기
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraPos.x));
        //ScreenToWorldPoint 카메라상의 2D를 3D로 치환, z축에는 카메라의x좌표를 넣음.
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);//target : 총이 바라보게할 목표물
        transform.LookAt(target);

    }
}
