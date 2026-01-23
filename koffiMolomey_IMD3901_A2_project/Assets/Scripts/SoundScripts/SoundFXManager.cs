using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    [Header("-------Audio Source------")]

    [SerializeField] AudioSource bgMusicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("-------Background Music Clips------")]
    public AudioClip BGMusic1;
    public AudioClip BGMusic2;


    [Header("-------SFX Clips------")]
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
        bgMusicSource.PlayOneShot(BGMusic2);

    }


    public void PlaySFX(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(audioClip);
    }



}
