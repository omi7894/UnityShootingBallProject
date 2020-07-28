using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ball_controller : MonoBehaviour
{
    public static bool canMove = false;
    int firemode = 0;

    [SerializeField] PickUpItem thePick;

    [Header("가로 속도변수")]
    [SerializeField] float moveSpeed;

    [Header("세로 속도변수")]
    [SerializeField] float moveSpeed2;


    [SerializeField] Renderer Rball;
    [SerializeField] Material red;
    [SerializeField] Material yellow;

    [SerializeField] GameObject fireImage;


    Rigidbody myRigid;

    public static bool IsJet = false;

    [Header("부터스 효과")]
    [SerializeField] ParticleSystem ps_boost;
    void Start()
    {
        Rball.gameObject.GetComponent<Renderer>();
        Rball.material = yellow;

        fireImage.SetActive(false);
        IsJet = false;
        myRigid = GetComponent<Rigidbody>();
        //초기값은 start에 넣는다.
        //GetComponent<> : <>안에있는 컴포넌트를 가져온다.
        //myRigid로 Rigidbody를 컨트롤 할수있음.
    }

    void Update()
    {/*
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * fHorizontal, Space.World);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * fVertical, Space.World);
         */
       
        if (Input.GetAxisRaw("Horizontal") != 0 && canMove)
        {
         

            Vector3 moveDir = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
            myRigid.AddForce(moveDir * moveSpeed);
            //Vertor3 : (x,y,z)의 float값을 갖고있음.
            //AddForce : 특정방향으로 힘을 가하는 메소드

        }
        if (Input.GetAxisRaw("Vertical") != 0 && canMove)
        {


            Vector3 moveDir = new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
            myRigid.AddForce(moveDir * moveSpeed2);

        }
        if (thePick.getShootingScore() % 3 == 0 && thePick.getShootingScore() > 0 && firemode==0)
        {
            firemode++;
        }
        if (firemode>0) {
            fireImage.SetActive(true);
        }
        if ( firemode>0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            ps_boost.Play();
            Rball.material = red;
            Invoke("turnOffBoost", 5f);
        }

        //Input : 마우스, 키보드, 조이스틱을 감지하는 클래스
        //GetAxisRaw 상, 하, 좌, 우에 따라 1 또는 -1을 리턴함.
        //Horizontal일 경우 좌우는 각각 -1,1   Vertical일 경우 상하는 각각 1,-1  

    }
    void turnOffBoost() {
        ps_boost.Stop();
        Rball.material = yellow;
        IsJet = false;
        firemode--;
    }
}
