using UnityEngine;

public class GrowFlowers : MonoBehaviour
{
    [SerializeField] GameObject Stem;

    [SerializeField] float increaseHeightValue = 0.1f;

    [SerializeField] float maxHeight = 1.4f;

    private void OnParticleCollision(GameObject other)
    {
        if (Stem.transform.localScale.y <= maxHeight)
        {
            Stem.transform.localScale += new Vector3(increaseHeightValue, increaseHeightValue, increaseHeightValue);
            Debug.Log("Growwwwwww");
            //keep going until reaches max height

        }
        else
        {
            Debug.Log("Max reached");
        }
    }



}
