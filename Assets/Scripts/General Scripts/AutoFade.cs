using UnityEngine;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
    public float visibleDuration;
    public float fadeDuration;
    public CanvasGroup group;

    private float startTime;

    public void Show()
    {
        startTime = Time.time;
        //SetAlpha(1f);
        group.alpha = 1f;
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
            //SetAlpha(1f - elapsedTime / fadeDuration);
            group.alpha = 1f - elapsedTime / fadeDuration;
        }
        else
        {
            Hide();
        }
    }

    /*public void SetAlpha(float alpha)
    {
        Color newColor = group.color;
        newColor.a = alpha;
        group.color = newColor;
    }*/

    public void Hide() => gameObject.SetActive(false);

    /*private void OnValidate()
    {
        group = GetComponent<Image>();
    }*/
}
