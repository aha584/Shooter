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

    [Header("Hit Marker Stuff")]
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;

    [Header("Event")]
    public UnityEvent onShoot;
    public UnityEvent onStop;

    private float lastShotTime;
    private float interval;
    private bool isStop;
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
        PerformRaycasting();
        onShoot.Invoke();
    }

    private void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        //Debug.Log("Get Aiming Ray");
        if(Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            //Debug.Log("Get Quaternion");
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
            //Debug.Log("Clone marker");
        }
    }
    private void StopMuzzle()
    {
        if (!isStop) return;
        if (timer < stopDuration) timer += Time.deltaTime;
        else
        {
            onStop.Invoke();
            timer = 0;
            isStop = false;
        }
    }
}
