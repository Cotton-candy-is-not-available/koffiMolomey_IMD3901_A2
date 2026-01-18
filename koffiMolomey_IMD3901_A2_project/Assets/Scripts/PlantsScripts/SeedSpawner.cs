using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    [SerializeField] int numOfSeeds = 5;

    public GameObject carrotSeedPrefab;



    // Update is called once per frame
    void Start()
    {
     //need to get correct range 
        for (int i = 0; i< numOfSeeds; i++)
        {
            //x axis         y axis             z axis
            Vector3 carrotSeedSpawnPos = new Vector3(Random.Range(4.5f, 5.0f), 1, Random.Range(-2.0f, 1.0f));//spawn within this range

            Instantiate(carrotSeedPrefab, carrotSeedSpawnPos, Quaternion.identity);// spawn carrot seed
        }
    }
}
