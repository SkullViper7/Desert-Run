using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFade : MonoBehaviour
{
    AudioSource source;
    public float maxVolume;
    public float minVolume;

    public float fadeOutDuration;

    private IEnumerator fadeOut;

    public static MusicFade instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FadeOut(source, fadeOutDuration, minVolume));
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
}
