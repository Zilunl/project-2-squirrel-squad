using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject star1 = GameObject.Find("FinalSoftStar");
        GameObject star2 = GameObject.Find("FinalSoftStar (1)");
        GameObject star3 = GameObject.Find("FinalSoftStar (2)");
        GameObject heart = GameObject.Find("FinalHeart");
        Color orange = new Color(1.0f, 0.5f, 0.0f);
        
        if (collision.gameObject.TryGetComponent(out NewPlayerControl player))
        {
            if (gameObject == star1)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            if (gameObject == star2)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            if (gameObject == star3)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = orange;
            }
            gameObject.GetComponent<StarAnimation>().isAnimated = false;
            gameObject.transform.eulerAngles = new Vector3(-90f, 90f, 90f);
        }
    }
    
}
