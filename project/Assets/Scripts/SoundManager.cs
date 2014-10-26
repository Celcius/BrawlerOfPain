using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    internal static SoundManager Instance;

    public AudioClip Hit;
    public AudioClip Dash;
    public AudioClip TrapDeath;
    public AudioClip FallDeath;

    private HashSet<AudioClip> waitingForSounds = new HashSet<AudioClip>();

    void Awake () {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlayHit()
    {
        PlaySound(Instance.Hit);
    }

    public static void PlayDash()
    {
        PlaySound(Instance.Dash);
    }

    public static void PlayTrapDeath()
    {
        PlaySound(Instance.TrapDeath);
    }

    public static void PlayFallDeath()
    {
        PlaySound(Instance.FallDeath);
    }

    static void PlaySound(AudioClip sound)
    {
        if (!Instance || Instance.waitingForSounds.Contains(sound))
            return;

        Instance.waitingForSounds.Add(sound);
        Instance.StartCoroutine(Instance.StopWaitingForSound(sound));
        Instance.audio.PlayOneShot(sound);
    }

    IEnumerator StopWaitingForSound(AudioClip sound)
    {
        yield return new WaitForSeconds(0.1f);
        waitingForSounds.Remove(sound);
    }

}
