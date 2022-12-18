using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 velocity;
    [SerializeField] private ParticleSystem collisionParticles;
    [SerializeField] private ParticleSystem deathEffect;
    private Rigidbody2D _rigidbody;
    [SerializeField] private string tagToDamage;


    private void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._rigidbody.velocity = this.velocity;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {       

        // check if the tartet is monster
        
        if (col.gameObject.CompareTag(this.tagToDamage))
        {
            // Damage object with relevant tag. Now updated to selectively
            // check if health manager exists. We also allow for the possibility
            // that the health manager could be in a parent object.
            var effect = Instantiate(deathEffect);
            effect.transform.position = transform.position;
            // destroy target
            Destroy(col.gameObject);
        }


        // cannon firing

        // Create collision particles in opposite direction to movement.
        /* var particles = Instantiate(this.collisionParticles);
        particles.transform.position = transform.position;
        particles.transform.rotation =
            Quaternion.LookRotation(col.GetContact(0).normal);
        */
        CannonTowerShoot.bulletDestroyed = true;

        var particles = Instantiate(this.collisionParticles);
        particles.transform.position = transform.position;
        particles.transform.rotation =
            Quaternion.LookRotation(col.GetContact(0).normal);
        // Destroy self.
        Destroy(gameObject);

    }


    // Update is called once per frame
    public void SetVelocity(Vector3 velocity)
    {
        this._rigidbody.velocity = velocity;
    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
