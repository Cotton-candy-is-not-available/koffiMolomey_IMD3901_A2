using System.Diagnostics;
using UnityEngine;

public class BGMusicChanger : MonoBehaviour
{
    public void ChangeSound(int num)
    {
        switch (num)
        {

            case 1:
                SoundManager.Instance.PlayBGMusic(SoundManager.Instance.BGMusic1);
                UnityEngine.Debug.Log("BG music 1");
                break;
            case 2:
                SoundManager.Instance.PlayBGMusic(SoundManager.Instance.BGMusic2);
                UnityEngine.Debug.Log("BG music 2");
                break;
        }

    }


    }
