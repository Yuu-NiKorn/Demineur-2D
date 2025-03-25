using UnityEngine;

public class Sounds : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource SFXSource;


    [Header("Audio Clip")]
    public AudioClip flag;
    public AudioClip bomb;
    public AudioClip tile;
    public AudioClip gameover;
    public AudioClip start;


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
