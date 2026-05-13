using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health health;
    public Image healthValueImage;

    public void HealthValueChanged(int currentValue, int maxValue)
    {
        healthValueImage.fillAmount = (float)currentValue / (float)maxValue;
    }
}
