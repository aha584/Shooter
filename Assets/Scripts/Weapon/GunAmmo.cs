using System;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public Shooting shooting;
    public Animator myAnimator;
    public AudioSource[] reloadSounds;
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

    private void LockSooting() => shooting.enabled = false;
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
        Debug.Log("Reload");
        myAnimator.SetTrigger("Reload");
        LockSooting();
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
}
