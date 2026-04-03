using UnityEngine;
using Random = UnityEngine.Random;

public class GunMuzzle : MonoBehaviour
{
    public GameObject muzzleGameObject;
    public float duration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideMuzzle();
    }
    public void ShowMuzzle()
    {
        muzzleGameObject.SetActive(true);
        //Debug.Log("Set Active = true");
        float randomRotateX = Random.Range(0, 360f);
        //Debug.Log("X = " + randomRotateX);
        muzzleGameObject.transform.localEulerAngles = new Vector3(randomRotateX, 
                                                                  muzzleGameObject.transform.localEulerAngles.y, 
                                                                  muzzleGameObject.transform.localEulerAngles.z);
        //CancelInvoke();
        //Invoke(nameof(HideMuzzle), duration);

    }
    public void HideMuzzle()
    {
        muzzleGameObject.SetActive(false);
    }
}
