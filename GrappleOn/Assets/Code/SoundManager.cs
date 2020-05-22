using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip coin, death, hook;
    static AudioSource audioSrc;
    void Start()
    {
        coin = Resources.Load<AudioClip>("coin");
        death = Resources.Load<AudioClip>("death");
        hook = Resources.Load<AudioClip>("hook");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coin":
                audioSrc.PlayOneShot(coin);
                break;
            case "death":
                audioSrc.PlayOneShot(death);
                break;
            case "hook":
                audioSrc.PlayOneShot(hook);
                break;



        }
    }
}
