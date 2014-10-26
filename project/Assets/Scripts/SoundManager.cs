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

    public void PlayHit()
    {
        audio.pitch = 1;
        audio.PlayOneShot(Hit);
    }

    public void PlayDash()
    {
        audio.pitch = 1;
        audio.PlayOneShot(Dash);
    }

    public void PlayTrapKill()
    {
        audio.pitch = 0.8f;
        audio.PlayOneShot(TrapKill);
    }

}
