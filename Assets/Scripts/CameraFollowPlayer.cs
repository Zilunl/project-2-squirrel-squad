using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] public NewPlayerControl player;
    [SerializeField] private Vector2 offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.dead)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }


    }
}
