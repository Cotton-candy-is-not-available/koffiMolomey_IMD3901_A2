using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("-------Audio Source------")]

    [SerializeField] AudioSource bgMusicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("-------Background Music Clips------")]
    public AudioClip BGMusic1;
    public AudioClip BGMusic2;


    [Header("-------SFX Clips------")]
    public AudioClip pickupSFX;
    public AudioClip throwSFX;
    public AudioClip createCropSFX;
    public AudioClip touchFloor;
    public AudioClip maxGrowth;



    public static SoundManager Instance;




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
        bgMusicSource.clip = BGMusic1;
        bgMusicSource.Play();

    }

    public void PlayBGMusic(AudioClip BGclip)
    {
        bgMusicSource.clip = BGclip;
        bgMusicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(audioClip);
    }



}
