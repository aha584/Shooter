using UnityEngine;
using TMPro;

public class AmmoTextBinder : MonoBehaviour
{
    public TMP_Text loadedAmmoText;
    public GunAmmo gunAmmo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunAmmo.loadedAmmoChanged.AddListener(UpdateGunAmmo);
        UpdateGunAmmo();
    }
    public void UpdateGunAmmo() => loadedAmmoText.text = gunAmmo.LoadedAmmo.ToString();
}
