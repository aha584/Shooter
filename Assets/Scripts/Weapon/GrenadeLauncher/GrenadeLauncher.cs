using UnityEngine;

public class GrenadeLauncher : Shooting
{
    [Header("Gun Stuff")]
    public Animator myAnimator;
    public AudioSource myAudioSource;

    [Header("Bullet Stuff")]
    public GameObject bulletPrefab;
    public Transform firingPos;
    public float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }
    private void ShootBullet() => myAnimator.SetTrigger("Shoot");

    public void PlayFireSound()
    {
        Debug.Log("Fire Sound");
    }
    public void AddProjectile()
    {
        Debug.Log("Add Projectile");
        GameObject projectile = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
        projectile.GetComponent<Rigidbody>().linearVelocity = firingPos.forward * bulletSpeed;
    }

}
