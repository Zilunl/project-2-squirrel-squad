using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] AudioSource myAudioSource;

    private bool killed = false;

    // may be overrode by child class   
    protected virtual void OnKilling(NewPlayerControl player)
    {
        player.Kill();
        if (myAudioSource != null && myAudioSource.clip != null)
        {
            myAudioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out NewPlayerControl player))
        {
            if (!killed)
            {
                OnKilling(player);
                if (!this.gameObject.CompareTag("Water"))
                {
                    player.PlayKillSound();
                }
                killed = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out NewPlayerControl player))
        {
            if (!killed)
            {
                OnKilling(player);
                player.PlayKillSound();
                killed = true;
            }
            
        }
    }
}
