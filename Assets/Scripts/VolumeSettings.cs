using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogError("AudioManager не знайдено!");
            return;
        }

        // Встановлюємо межі повзунка
        volumeSlider.minValue = 0f;
        volumeSlider.maxValue = 1f;

        // Завантажуємо збережену гучність
        volumeSlider.SetValueWithoutNotify(
            AudioManager.Instance.CurrentVolume
        );

        // Підключаємо повзунок
        volumeSlider.onValueChanged.AddListener(
            AudioManager.Instance.SetVolume
        );
    }

    private void OnDestroy()
    {
        if (AudioManager.Instance != null && volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(
                AudioManager.Instance.SetVolume
            );
        }
    }
}