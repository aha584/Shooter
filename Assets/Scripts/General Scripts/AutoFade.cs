using UnityEngine;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
    public float visibleDuration;
    public float fadeDuration;
    public Image image;

    private float startTime;

    public void Show()
    {
        startTime = Time.time;
        SetAlpha(1f);
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime < visibleDuration) return;

        elapsedTime -= visibleDuration;
        if (elapsedTime < fadeDuration)
        {
            SetAlpha(1f - elapsedTime / fadeDuration);
        }
        else
        {
            Hide();
        }
    }

    public void SetAlpha(float alpha)
    {
        Color newColor = image.color;
        newColor.a = alpha;
        image.color = newColor;
    }

    public void Hide() => gameObject.SetActive(false);

    private void OnValidate()
    {
        image = GetComponent<Image>();
    }
}
