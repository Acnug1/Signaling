using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private Coroutine _signaling;

    public void StartVolumeChanger(bool onEnable)
    {
        if (_signaling != null)
            StopCoroutine(_signaling);

        _signaling = StartCoroutine(ChangeIn(onEnable));
    }

    private IEnumerator ChangeIn(bool onEnabled)
    {
        var waitForEndOfFrame = new WaitForEndOfFrame();

        if (onEnabled)
        {
            _audio.Play();

            for (int i = 0; i < 101; i++)
            {
                _audio.volume = i * 1f / 100f;

                yield return waitForEndOfFrame;
            }
        }
        else
        {
            for (int i = 0; i < 101; i++)
            {
                _audio.volume = 1f - (i * 1f / 100f);

                yield return waitForEndOfFrame;
            }

            _audio.Stop();
        }
    }
}
