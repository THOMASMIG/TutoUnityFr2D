using UnityEngine;
using UnityEngine.UI;

public class MyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealt(int Health)
    {
        slider.maxValue = Health;
        SetHealth(Health);

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int Health)
    {
        slider.value = Health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
