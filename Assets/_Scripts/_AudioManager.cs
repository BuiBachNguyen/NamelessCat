using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class _AudioManager : MonoBehaviour
{
    public static _AudioManager Instance; // Singleton để dễ truy cập

    [Header("--------- Audio Source ---------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;
    public AudioSource SFXSourceForWalk;
    [Space(5)]
    [Header("--------- Audio Clips ---------")]
    public AudioClip Background1;
    public AudioClip Background2;
    public AudioClip Death;
    public AudioClip Walk;
    public AudioClip Teleport;
    public AudioClip TrapFall;
    public AudioClip RabbitCharge;
    public AudioClip Click;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //  DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        musicSource.clip = Background1;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlayWalkSound()
    {
        SFXSourceForWalk.clip = Walk;
        SFXSourceForWalk.Play();
    }
    public void StopWalkSound()
    {
        SFXSourceForWalk.Stop();
    }
}
