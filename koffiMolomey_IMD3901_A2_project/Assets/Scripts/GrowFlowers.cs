using UnityEngine;

public class GrowFlowers : MonoBehaviour
{
    [SerializeField] GameObject flower;

    [SerializeField] float increaseHeightValue = 0.1f;

    [SerializeField] float maxHeight = 1.4f;

    bool maxReached = false;

    private void OnParticleCollision(GameObject other)
    {
        if (flower.transform.localScale.y < maxHeight)
        {
            flower.transform.localScale += new Vector3(increaseHeightValue, increaseHeightValue, increaseHeightValue);
            //Debug.Log("Growwwwwww");
            //keep going until reaches max height

        }
        if (flower.transform.localScale.y <= maxHeight && maxReached == false)
        {
            SoundManager.Instance.PlaySFX(SoundManager.Instance.maxGrowth);
            //Debug.Log("Max reached");
            maxReached = true;

        }
    }



}
