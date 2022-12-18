using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedRain : KillPlayer
{

    [SerializeField] private LayerMask MushroomLayer;

    private bool killed = false;

    protected override void OnKilling(NewPlayerControl player)
    {

        Vector2 start = new Vector2(transform.position.x, transform.position.y);
        Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
        

        if (!Physics2D.Linecast(start, target, MushroomLayer))
        {
            base.OnKilling(player);
            if (!killed)
            {
                player.PlayKillSound();
                killed = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out NewPlayerControl player))
        {
            OnKilling(player);
            
            
        }
    }

}
