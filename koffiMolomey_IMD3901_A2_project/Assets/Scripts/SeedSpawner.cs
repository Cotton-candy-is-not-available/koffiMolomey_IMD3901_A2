using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    public GameObject seedPrefab;



    // Update is called once per frame
    public void SpawnSeed()
    {
        Instantiate(seedPrefab, new Vector3(0.4f, 1.4f, -0.4f), Quaternion.identity);
    }
}
