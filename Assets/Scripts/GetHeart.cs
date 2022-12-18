using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetHeart : MonoBehaviour
{
    [SerializeField] AudioSource myAudioSource;
    [SerializeField] private float goalMenuTimer = 2;
    [SerializeField] private bool isGoal = true;
    [SerializeField] private bool touched = false;
    private bool isFinal = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject star1 = GameObject.Find("FinalSoftStar");
        GameObject star2 = GameObject.Find("FinalSoftStar (1)");
        GameObject star3 = GameObject.Find("FinalSoftStar (2)");
        if (gameObject == star1 || gameObject == star2 || gameObject == star3) {
            isFinal = true;
        }
        if (collision.gameObject.TryGetComponent(out NewPlayerControl player))
        {
            gameObject.GetComponent<StarAnimation>().isAnimated = false;
            gameObject.transform.eulerAngles = new Vector3(-90f, 0f, 0f);

            // play the audio only once
            if (!touched)
            {
                if (myAudioSource != null && myAudioSource.clip != null)
                {
                    myAudioSource.Play();
                }
            }
            touched = true;
        }
        
    }
    void Update()
    {
        GameObject heart = GameObject.Find("FinalHeart");
        float position = 0.0f;
        if (gameObject == heart) {
            position = 5.0f;
        } else {
            position = 4.0f;
        }
        if (gameObject.GetComponent<StarAnimation>().isAnimated == false && gameObject.transform.position.y < position)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
            if (isFinal == false && gameObject.transform.localScale.x < 1.8f) {
                this.transform.localScale += Vector3.one * Time.deltaTime;
            }
        }

        if (touched)
        {
            // End of the level
            if (isGoal)
            {
                if (SceneManager.GetActiveScene().name == "Level 1")
                {
                    GameOperator.Instance.lv2 = true;
                }
                else if(SceneManager.GetActiveScene().name == "Level 2")
                {
                    GameOperator.Instance.lv3 = true;
                }
                // wait for a while to load the goal menu
                if (goalMenuTimer > 0)
                {
                    goalMenuTimer -= Time.deltaTime;
                }
                else
                {
                    GameOperator.Instance.LoadGoalMenu();
                }
            }
            
        }
    }

}
