using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float gameOverTimer = 3;

    [Header("Assignments")]
    [SerializeField] private AudioClip levelBGM;

    public AudioSource winBGM;

    public NewPlayerControl player;

    public GameObject pauseMenu;
    public GameObject goalMenu;

    public static bool isPasued = false;   // game pause

    private bool winBgmPlayed;

    [SerializeField] private GameObject cannonTower;
    [SerializeField] private float cannonDisplayDist = 50;


    void Start()
    {
        //BGM:
        if (levelBGM != null)
        {
            // singleton
            GameOperator.Instance.PlayBGM(levelBGM);
        } 
        else
        {
            Debug.Log("ERROR, no BGM assigned!");
        }

        // assin itself to game operator
        GameOperator.Instance.activeLevelManager = this;

        // close the manu if it's open
        if (pauseMenu != null && pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false);
        }
 
        isPasued = false;
        Time.timeScale = 1;
        winBgmPlayed = false;

        // only in level 1
        if (cannonTower != null)
        {
            cannonTower.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.dead)
        {
            Scene scene = SceneManager.GetActiveScene();

            if (gameOverTimer > 0)
            {
                gameOverTimer -= Time.deltaTime;
            } else
            {
                SceneManager.LoadScene(scene.name);
            }
        }

        if (goalMenu.activeSelf)
        {
            // play win bgm
            if (winBGM != null && winBGM.clip != null)
            {
                GameOperator.Instance.StopBGM();
                if (!winBGM.isPlaying && !winBgmPlayed)
                {
                    winBGM.Play();
                    winBgmPlayed = true;
                }
            }
        }


        // only display when the fox gets close to it (in level 1)
        if (cannonTower != null)
        {
            if (Math.Abs(cannonTower.transform.position.x - player.transform.position.x) < cannonDisplayDist)
            {
                cannonTower.SetActive(true);
            }
            else
            {
                cannonTower.SetActive(false);
            }
        }

        


    }

    public void LoadGoalMenu()
    {
        if (goalMenu != null)
        {
            goalMenu.SetActive(true);
            isPasued = true;
            Time.timeScale = 0;
        }
    }

    public void GoToLevel2()
    {
        goalMenu.SetActive(false);
        isPasued = false;
        SceneManager.LoadScene("Level 2");
    }

    public void GoToLevel3()
    {
        goalMenu.SetActive(false);
        isPasued = false;
        SceneManager.LoadScene("Level 3");
    }

    public void GoToFinalScene()
    {
        goalMenu.SetActive(false);
        isPasued = false;
        SceneManager.LoadScene("FinalScene");
    }

    public void LoadPauseMenu()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            isPasued = true;
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        isPasued = false;
        Time.timeScale = 1;
    }

    public void GoToMain()
    {
        goalMenu.SetActive(false);
        isPasued = false;
        SceneManager.LoadScene("StartScene");
    }

    public void OnApplicationQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
