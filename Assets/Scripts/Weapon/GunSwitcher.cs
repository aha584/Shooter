using UnityEngine;
using System.Collections.Generic;

public class GunSwitcher : MonoBehaviour
{
    public List<GameObject> guns = new(); 

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < guns.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) 
                || Input.GetKeyDown(KeyCode.Keypad1 + i))
            {
                SetActiveGun(i);
            }
        }
    }
    private void SetActiveGun(int gunIndex)
    {
        for(int i=0;i<guns.Count;i++)
        {
            bool isActive = (i == gunIndex);
            guns[i].SetActive(isActive);
            if(isActive)
            {
                guns[i].SendMessage("OnGunSelected", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
