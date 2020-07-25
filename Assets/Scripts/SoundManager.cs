using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound {
    public string soundName;
    public AudioClip clip;
}
//MP3파일역할

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    //Static : 공유변수. 어디서든 쉽게 변경 가능하도록 
    //이 클래스 자체를 Static 변수로 만든다. 
    
    [Header("사운드 등록")]
    [SerializeField] Sound[] bgmSounds;//브금
    [SerializeField] Sound[] sfxSounds;//효과음

    [Header("브금 플레이어")]
    [SerializeField] AudioSource bgmPlayer; 

    [Header("효과음 플레이어")]
    [SerializeField] AudioSource[] sfxPlayer; //효과음 여러개이므로 배열로

    //AudioSource : MP3플레이어 역할
    //AudioSource 안에 AudioClip을 넣어줘야함.
    private void Start()
    {
        instance = this; //instace에 자기자신 넣어줌.
        PlayRandomBGM();
    }
    
    public void PlayRandomBGM()
    {
        //int random = Random.Range(0, 2); //랜덤값이 0또는1 (비지엠 2개)
        
            bgmPlayer.clip = bgmSounds[0].clip;
            bgmPlayer.Play();
    }

    public void PlaySE(string _soundName) {
        for (int i = 0; i < sfxSounds.Length; i++) { //사운드개수만큼 반복

            if (_soundName == sfxSounds[i].soundName){ //조건과 동일한 효과음을 찾았다면

                for (int x = 0; x < sfxPlayer.Length; x++) {
                   // if (!sfxPlayer[x].isPlaying) { //그효과음이 재생중이지 않다면
                        sfxPlayer[x].clip = sfxSounds[i].clip;
                        sfxPlayer[x].Play(); //MP3재생
                        return; //한번재생하고 반복문 빠져나와야함.
                  //  }
                }
                //Debug.Log("모든 효과음 플레이어가 사용중입니다!!"); //원하는 효과음이 재생중일때
                return;
            }
        }
        Debug.Log("등록된 효과음이 없습니다."); //원하는 효과음 없을때
    }
  
   
}
