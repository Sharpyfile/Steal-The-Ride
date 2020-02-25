using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponFire : MonoBehaviour
{
    public float fireCooldown = 2f;
    public GameObject bullet;
    public GameObject dynamite;
    //public ParticleSystem particleSystem;
    public int fireParticleCount = 10;
    public float speed = 2f;
    public int revolverMagazineSize = 6;
    public int bulletsInRevolverMagazine = 6;

    private float range = 1.5f;
    private float timestampFiring;
    private GameObject player;
    private Transform playerToFollow;

    public BossRotation bossRotation;
    private int stageFlag; //1 -> 1st phase, 2 -> 2nd phase


    // Start is called before the first frame update
    void Start()
    {
        timestampFiring = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        playerToFollow = player.transform;
        stageFlag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetPhaseFlag();
        
        if (stageFlag == 1)
        {
            if (bossRotation.firstPhaseMove == true && bossRotation.firstPhaseTNT == false)
            {
                if (timestampFiring <= Time.time && Vector2.Distance(transform.position, playerToFollow.position) < 1.5f * range && bulletsInRevolverMagazine > 0)
                {
                    Fire();
                }

                if (bulletsInRevolverMagazine == 0)
                {
                    Invoke("Reload", revolverMagazineSize);
                }
            }
            else if (bossRotation.firstPhaseMove == false && bossRotation.firstPhaseTNT == true)
            {
                //ThrowTNT();
            }
            
            
        }
        else if (stageFlag == 2)
        {
            if (bossRotation.secondPhaseTNT == false && bossRotation.secondPhaseMachineGun == true)
            {
                ShootMachineGun();
            }
            else if (bossRotation.secondPhaseTNT == true && bossRotation.secondPhaseMachineGun == false)
            {
                ThrowTNT();
            }
        }  
    }

    void Fire()
    {
        timestampFiring = Time.time + fireCooldown;
        //particleSystem.Emit(fireParticleCount);

        GameObject newBullet = GameObject.Instantiate(bullet, transform.position, transform.rotation);
        newBullet.SetActive(true);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);

        bulletsInRevolverMagazine--;
    }

    void Reload()
    {
        bulletsInRevolverMagazine = revolverMagazineSize;
    }

    void ThrowTNT()
    {
        timestampFiring = Time.time + fireCooldown * 2;

        GameObject newDynamite = GameObject.Instantiate(dynamite, transform.position, transform.rotation);
        newDynamite.SetActive(true);
        Rigidbody2D rb = newDynamite.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed/2.0f, ForceMode2D.Impulse);
        rb.AddTorque(transform.right.x, ForceMode2D.Impulse);
    }

    void ShootMachineGun()
    {
        timestampFiring = Time.time + fireCooldown/6;
        //particleSystem.Emit(fireParticleCount);

        GameObject newBullet = GameObject.Instantiate(bullet, transform.position, transform.rotation);
        newBullet.SetActive(true);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        rb.AddForce(transform.up * Random.Range(-0.2f, 0.2f), ForceMode2D.Impulse);
    }

    void SetPhaseFlag()
    {
        if(bossRotation.firstPhase == true && bossRotation.secondPhase == false)
        {
            stageFlag = 1;
        }
        else if (bossRotation.firstPhase == false && bossRotation.secondPhase == true)
        {
            stageFlag = 2;
        }
    }
}
