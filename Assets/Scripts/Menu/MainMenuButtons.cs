using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject main;
    public GameObject intro;
    public GameObject instruction;
    public GameObject instruction2;
    public GameObject instruction3;
    public GameObject levels;

    private void Start()
    {
        main.SetActive(true);
    }

    public void GoToIntro()
    {
        intro.SetActive(true);
        main.SetActive(false);
    }

    public void GoToIns()
    {
        instruction.SetActive(true);
        main.SetActive(false);
        instruction2.SetActive(false);
    }

    public void GoToIns2()
    {
        instruction2.SetActive(true);
        instruction.SetActive(false);
        instruction3.SetActive(false);
    }

    public void GoToIns3()
    {
        instruction3.SetActive(true);
        instruction2.SetActive(false);
    }

    public void GoToLevels()
    {
        levels.SetActive(true);
        GameObject btn2 = GameObject.Find("B_Level2");
        GameObject btn3 = GameObject.Find("B_Level3");
        btn2.GetComponent<UnityEngine.UI.Button>().interactable = GameOperator.Instance.lv2;
        btn3.GetComponent<UnityEngine.UI.Button>().interactable = GameOperator.Instance.lv3;
        main.SetActive(false);
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }


    public void GoBackToMain()
    {
        main.SetActive(true);
        intro.SetActive(false);
        instruction.SetActive(false);
        instruction2.SetActive(false);
        instruction3.SetActive(false);
        levels.SetActive(false);
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
