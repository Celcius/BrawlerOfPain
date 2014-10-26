using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    internal static SoundManager Instance;

    public AudioClip Hit;
    public AudioClip Dash;
    public AudioClip TrapKill;


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
        Instance.audio.pitch = 1;
        Instance.audio.PlayOneShot(Instance.Hit);
    }

    public static void PlayDash()
    {
        if (!Instance)
            return;
        Instance.audio.pitch = 1;
        Instance.audio.PlayOneShot(Instance.Dash);
    }

    public static void PlayTrapKill()
    {
        if (!Instance)
            return;
        Instance.audio.pitch = 0.75f;
        Instance.audio.PlayOneShot(Instance.TrapKill);
    }

}
