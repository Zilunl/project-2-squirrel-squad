using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOperator : MonoBehaviour
{

    [SerializeField] public AudioSource bgmPlayer;

    public static GameOperator Instance;
    public LevelManager activeLevelManager;
    public bool lv2 = false;
    public bool lv3 = false;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (activeLevelManager != null && Input.GetKeyDown(KeyCode.Escape))
        {
            activeLevelManager.LoadPauseMenu();
        }
    }

    public void LoadGoalMenu()
    {
        if (activeLevelManager != null)
        {
            activeLevelManager.LoadGoalMenu();
        }
    }

    public void PlayBGM(AudioClip newBGM)
    {
        if (newBGM != null)
        {
            if (newBGM != bgmPlayer.clip)
            {
                bgmPlayer.clip = newBGM;
                bgmPlayer.Play();
            }

            if(!bgmPlayer.isPlaying)
            {
                bgmPlayer.Play();
            }
            
        }
    }

    public void StopBGM()
    {
        if (bgmPlayer.isPlaying) bgmPlayer.Stop();
    }
}
