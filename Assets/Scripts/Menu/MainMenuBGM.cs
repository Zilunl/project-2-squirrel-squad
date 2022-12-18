using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBGM : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    
    void Start()
    {
        //BGM
        if (bgm != null && bgm.clip != null)
        {
            // singleton
            if (GameOperator.Instance.bgmPlayer.isPlaying)
            {
                GameOperator.Instance.StopBGM();
            }
            bgm.Play();
        }
        else
        {
            Debug.Log("ERROR, no BGM assigned!");
        }
    }


}
