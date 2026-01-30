using UnityEngine;

public class hitGroundCheck : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance.touchFloor);//if something hits the floor it makes a thud sound
    }
}
