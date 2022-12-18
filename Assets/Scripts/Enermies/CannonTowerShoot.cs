using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTowerShoot : MonoBehaviour
{


    [SerializeField] private ProjectileController projectilePrefab;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private double shootCoolDown;
    [SerializeField] private Transform shootPoint;

    public AudioSource hitAudio;
    public static bool bulletDestroyed = false;

    private bool isCoolDown = false;
    public double coolDownLeftSec;
    private float totalTimer;
    
    void Update()
    {
        if (bulletDestroyed)
        {
            if (hitAudio != null && hitAudio.clip != null)
            {
                hitAudio.Play();
                bulletDestroyed = false;
            }
        }

        totalTimer += Time.deltaTime;
        if (totalTimer >= 1)
        {
            if (coolDownLeftSec > 0)
            {
                coolDownLeftSec--;

            }
            else
            {
                isCoolDown = false;
            }
            totalTimer = 0;
        }
        
        if (isCoolDown == false)
        {
            Fire();
            isCoolDown = true;
            coolDownLeftSec = shootCoolDown - 1f;//cool down would count to 0, so -1
           
        }
    }

    void Fire() {
        Instantiate(this.projectilePrefab, this.shootPoint.position + new Vector3(-1,0,0), Quaternion.identity)
            .SetVelocity(new Vector2(-1, 0) * this.projectileSpeed);
    }
}
