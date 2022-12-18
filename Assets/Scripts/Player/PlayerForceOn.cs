using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceOn : MonoBehaviour
{

    private NewPlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<NewPlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.enabled == false)
        {
            player.enabled = true;
        }
    }
}
