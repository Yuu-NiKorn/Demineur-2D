using UnityEngine;

public class Sounds : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource SFXSource;


    [Header("Audio Clip")]
    public AudioClip[] audioList;
    
    public void PlaySFX(int index)
    {
        SFXSource.PlayOneShot(audioList[index]);
    }
}
