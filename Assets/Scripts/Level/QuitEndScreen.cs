using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitEndScreen : MonoBehaviour
{
    public AudioSource source;
    public float maxVolume;
    public float minVolume;

    public float fadeOutDuration;

    private IEnumerator fadeOut;

    public static QuitEndScreen instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public IEnumerator FadeOut(AudioSource aSource, float duration, float targetVolume)
    {
        float timer = 0f;
        float currentVolume = aSource.volume;
        float targetValue = Mathf.Clamp(targetVolume, minVolume, maxVolume);

        while (aSource.volume > 0)
        {
            timer += Time.deltaTime;
            var newVolume = Mathf.Lerp(currentVolume, targetValue, timer / duration);
            aSource.volume = newVolume;
            yield return null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            SceneManager.LoadScene("Menu");
        }
        Invoke("AutoQuit", 23.5f);
    }

    void AutoQuit()
    {
        StartCoroutine(FadeOut(source, fadeOutDuration, minVolume));
        Invoke("QuitToMenu", fadeOutDuration);
    }

    void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
