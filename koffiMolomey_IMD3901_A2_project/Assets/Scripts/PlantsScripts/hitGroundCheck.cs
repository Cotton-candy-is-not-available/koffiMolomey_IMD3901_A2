using UnityEngine;

public class hitGroundCheck : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Floor")//if it collides with the dirt
        //{
            SoundFXManager.Instance.PlaySFX(SoundFXManager.Instance.touchFloor);

        //}
    }
}
