using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    [Header("Audio Source------")]

    [SerializeField] AudioSource bgMusicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("Audio Source------")]
    public AudioClip pickupSFX;



    public static SoundFXManager Instance;




    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void Start()
    {
        //Play bg music
    }


    public void PlaySFX(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(audioClip);
    }



}
