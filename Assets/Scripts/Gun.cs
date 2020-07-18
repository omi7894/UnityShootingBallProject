using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { 
    Normal_Gun,
}
//enum : 열거된 데이터 중에서 하나 선택할수있는 자료형
public class Gun : MonoBehaviour
{
    [Header("총 유형")]
    public WeaponType weaponType;

    [Header("총 연사 속도")]
    public float fireRate;

    [Header("총알 개수")]
    public int bulletCount; //현재 총알 몇발 있는지
    public int maxBulletCount;//최대 몇발 소유할수 있는지

    [Header("총구 섬광")]
    public ParticleSystem ps_gunflash;

    [Header("총알")]
    public GameObject bullet_prefab;

    [Header("총알 스피드")]
    public float speed;

}
