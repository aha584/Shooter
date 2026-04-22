using System;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public Shooting shooting;
    public Animator myAnimator;
    public AudioSource[] reloadSounds;
    //Can use solution 2  for this
    //Use UnityEvent<int> and invoke with _loadedAmmo in this.
    //In AmmoText, we no need to implement GunAmmo ref to that script
    public UnityEvent loadedAmmoChanged;

    [SerializeField] private int _loadedAmmo;

    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            loadedAmmoChanged.Invoke();
            if(_loadedAmmo <=0)
            {
                Reload();
            }
            else
            {
                UnlockSooting();
            }
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() => RefillAmmo();

    private void LockShooting() => shooting.enabled = false;
    private void UnlockSooting() => shooting.enabled = true;
    public void SingleFireAmmoCounter() => LoadedAmmo--;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Reload()
    {
        LockShooting();
        Debug.Log("Reload");
        myAnimator.SetTrigger("Reload");
    }
    public void AddAmmo() => RefillAmmo();

    private void RefillAmmo() => LoadedAmmo = magSize;

    public void PlayReloadSound1()
    {
        Debug.Log("Sound 1");
    }
    public void PlayReloadSound2()
    {
        Debug.Log("Sound 2");
    }
    public void PlayReloadSound3()
    {
        Debug.Log("Sound 3");
    }
    public void PlayReloadSound4()
    {
        Debug.Log("Sound 4");
    }
    public void PlayReloadSound5()
    {
        Debug.Log("Sound 5");
    }

    public void OnGunSelected() => UpdateShootingLock();

    private void UpdateShootingLock() => shooting.enabled = _loadedAmmo > 0;
}
