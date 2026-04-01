using System;
using UnityEngine;

public class AutomaticShooting : MonoBehaviour
{
    [Header("Gun Stuff")]
    public Animator myAnimator;
    public int rpm;
    public AudioSource shootSound;

    private float lastShotTime;
    private float interval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interval = 60f / rpm;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }

    private void UpdateFiring()
    {
        if(Time.time - lastShotTime >= interval)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }
    private void Shoot()
    {
        myAnimator.Play("Shoot", layer: -1, normalizedTime: 0);
        Debug.Log("Shoot Sound Play");
    }
}
