using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle : MonoBehaviour
{
    public Enemy FireballPrefab;
    public float fireballSpeed;
    public Vector2 shootDirectionAngle;

    public SoundType ShootFireballSFX;

    public float rateOfFire;
    void Start()
    {
        StartCoroutine(ShootFireball());
    }

    IEnumerator ShootFireball()
    {
        yield return new WaitForSeconds(rateOfFire);

        float angle = Vector2.Angle(new Vector2(0, 0), shootDirectionAngle);
        Singleton.Main.AudioManager.Play(ShootFireballSFX);
        Enemy projectile = GameObject.Instantiate(FireballPrefab, transform.position + new Vector3(1 * transform.localScale.x, 0, 0), Quaternion.Euler(0, 0, angle));

        //make fireball inherit scale
        Entity fireball = projectile.GetComponent<Entity>();
        fireball.transform.localScale = transform.localScale;
        ParticleSystem embers = fireball.GetComponentInChildren<ParticleSystem>();
        embers.transform.localScale = transform.localScale;
        
        fireball.movement.SetVelocityX(fireballSpeed * shootDirectionAngle.x);
        fireball.movement.SetVelocityY(fireballSpeed * shootDirectionAngle.y);

        StartCoroutine(ShootFireball());
    }

}
