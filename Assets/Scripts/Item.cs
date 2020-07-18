using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType //아이템 유형
{
    Score, Monster,
}
public class Item : MonoBehaviour
{
    public ItemType itmeType;

    public int extraScore;//추가점수
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
