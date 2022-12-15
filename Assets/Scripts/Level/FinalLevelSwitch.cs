using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelSwitch : MonoBehaviour
{
    private int nextSceneToLoad;

    public AudioSource source;
    public float maxVolume;
    public float minVolume;

    public float fadeOutDuration;

    private IEnumerator fadeOut;

    public static FinalLevelSwitch instance;

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

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FadeOut(source, fadeOutDuration, minVolume));
            Invoke("LoadLevel", fadeOutDuration);
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
