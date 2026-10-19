using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private const string VolumeKey = "MasterVolume";

    [Range(0f, 1f)]
    public float defaultVolume = 1f;

    public float CurrentVolume { get; private set; }

    private void Awake()
    {
        // Перевіряємо, чи вже існує AudioManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Зберігаємо об'єкт між сценами
        DontDestroyOnLoad(gameObject);

        // Завантажуємо збережену гучність
        CurrentVolume = PlayerPrefs.GetFloat(
            VolumeKey,
            defaultVolume
        );

        ApplyVolume();
    }

    // Змінюємо гучність
    public void SetVolume(float volume)
    {
        CurrentVolume = Mathf.Clamp01(volume);

        ApplyVolume();

        // Зберігаємо налаштування
        PlayerPrefs.SetFloat(VolumeKey, CurrentVolume);
        PlayerPrefs.Save();
    }

    // Застосовуємо гучність до всієї гри
    private void ApplyVolume()
    {
        AudioListener.volume = CurrentVolume;
    }
}