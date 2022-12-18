using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera playerCamera;
    [SerializeField] Rigidbody2D playerRigidbody;
    Animator animator;
    MeshRenderer playerMeshRender;
    [SerializeField] private float speed;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private ProjectileController projectilePrefab;
    [SerializeField] private int shootCoolDown;
    //[SerializeField] private RigidbodyLookRotation bodyLookRotation;

  
    

    [Header("Player Control")]
    [SerializeField] float jumpSpeed = 5;

    private Plane _gamePlane;
    private Vector3 _aimDirection;


    private bool grounded = true;
    private bool isCoolDown = false;
    public bool dead = false;
    public int coolDownLeftSec;
    private float totalTimer;

    public AudioSource jumpAudio;
    public AudioSource fireAudio;
    public AudioSource dieAudio;

    public GameObject cdHintPoint;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //playerMeshRender = GetComponent<MeshRenderer>();
        //playerMeshRender.material.color = Color.red;
        this._aimDirection = Vector2.right;
        this._gamePlane = new Plane(Vector3.back, Vector3.zero);
        playerRigidbody.freezeRotation = true;

    }

    
    private void Update()
    {
        if (LevelManager.isPasued)
        {
            return;
        }

        // if plyar is dead, stop player control
        if (this.dead)
        {
            animator.SetBool("Dead", true);
            return;

        };

        Aim();
        // keyboard move
        float h=0;
    
        
        
        bool l = Input.GetKey(KeyCode.A);
        bool r = Input.GetKey(KeyCode.D);

        if (l)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            h = -1;
        }

        if (r)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            h = 1;
        }
        bool walking = h != 0f;


        if (walking)
        {
            animator.SetBool("Start", true);
            animator.SetBool("Run", true);
        }else
        {
            animator.SetBool("Run", false);
        }
        

        

        
        transform.Translate(Vector2.right * h * speed * Time.deltaTime, Space.World); // A D 

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded == true)
            {
                playerRigidbody.velocity += new Vector2(0, jumpSpeed); //add acceleration
                grounded = false;
                animator.SetBool("Jump", grounded);
                if (jumpAudio != null && jumpAudio.clip != null)
                {
                    jumpAudio.Play(); ;
                }
                
            }
        }
        
        // calculate time duration and cool down
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
                cdHintPoint.SetActive(true);
            }
            totalTimer = 0;
        }

        if (Input.GetMouseButtonDown(0) && isCoolDown == false) 
        { 
            Fire();
            isCoolDown = true;
            coolDownLeftSec = shootCoolDown - 1;//cool down would count to 0, so -1
            if (fireAudio != null && fireAudio.clip != null)
            {
                fireAudio.Play();
            }
            cdHintPoint.SetActive(false);
        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        animator.SetBool("Jump", grounded);
    }
    
    private void Aim()
    {
        // Fire a ray into the world given the current mouse position and get
        // the projected hit point on the x-z gameplay plane (y = 0). This can
        // be used to derive the aim direction.
        var ray = this.playerCamera.ScreenPointToRay(Input.mousePosition);
        

        if (this._gamePlane.Raycast(ray, out var distance))
        {
            
            var target = ray.GetPoint(distance);
            this._aimDirection = (target - this.playerRigidbody.transform.position).normalized;
            

            // Update look direction target so player rotates appropriately.
            //this.bodyLookRotation.SetLookDirection(this._aimDirection);
        }
        
    }

    private void Fire()
    {
        if (Input.mousePosition.x > Screen.width / 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        Instantiate(this.projectilePrefab, this.playerRigidbody.transform.position + _aimDirection * 2f, Quaternion.identity)
            .SetVelocity(this._aimDirection * this.projectileSpeed);
        animator.SetTrigger("Attack");

        // Apply recoil impulse.
        /*this.playerRigidbody.AddForce(
            -this._aimDirection * this.projectileSpeed, ForceMode2D.Impulse);
        */
    }
        

    public void PlayKillSound()
    {
        dieAudio.Play();
    }

    public void Kill()
    {
        this.dead = true;
    }
}
