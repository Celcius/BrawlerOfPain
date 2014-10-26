using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    internal static SoundManager Instance;

    public AudioClip Hit;
    public AudioClip Dash;
    public AudioClip TrapDeath;
    public AudioClip FallDeath;

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
        if (!Instance)
            return;
        Instance.audio.PlayOneShot(Instance.Hit);
    }

    public static void PlayDash()
    {
        if (!Instance)
            return;
        Instance.audio.PlayOneShot(Instance.Dash);
    }

    public static void PlayTrapDeath()
    {
        if (!Instance)
            return;
        Instance.audio.PlayOneShot(Instance.TrapDeath);
    }

    public static void PlayFallDeath()
    {
        if (!Instance)
            return;
        Instance.audio.PlayOneShot(Instance.FallDeath);
    }

}
