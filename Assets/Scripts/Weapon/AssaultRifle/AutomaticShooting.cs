using System;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : Shooting
{
    [Header("Gun Stuff")]
    public Animator myAnimator;
    public int rpm;
    public AudioSource shootSound;
    //public GunAmmo myAmmo;

    public GunRaycaster gunRaycaster;

    [Header("Event")]
    public UnityEvent onShoot;
    public UnityEvent onStop;

    private float lastShotTime;
    private float interval;
    [SerializeField] private bool isStop;
    [SerializeField] private float stopDuration;
    private float timer = 0f;

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
        else if(Input.GetMouseButtonUp(0))
        {
            isStop = true;
        }
        StopMuzzle();
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
        gunRaycaster.PerformRaycasting();
        onShoot.Invoke();
    }
    private void StopMuzzle()
    {
        if (!isStop) return;
        if (timer < stopDuration) timer += Time.deltaTime;
        else
        {
            StopInvoke();
            timer = 0;
            isStop = false;
        }
    }
    public void StopInvoke()
    {
        Debug.Log("Stop Invoke");
        onStop.Invoke();
    }
}
