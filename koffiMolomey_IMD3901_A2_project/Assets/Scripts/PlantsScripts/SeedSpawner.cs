using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    [SerializeField] int numOfSeeds = 5;

    public GameObject carrotSeedPrefab;
    public GameObject cabbageSeedPrefab;

    float yPos = 1.0f;
    float zPos = -2.47199988f;


    // Update is called once per frame
    void Start()
    {
     //need to get correct range 
        for (int i = 0; i< numOfSeeds; i++)
        {
            Vector3 carrotSeedSpawnPos = new Vector3(4.8f, yPos, -1.2f);//spawn within this range
            Instantiate(carrotSeedPrefab, carrotSeedSpawnPos, Quaternion.identity);// spawn carrot seed

            Vector3 cabbageSeedSpawnPos = new Vector3(4.76000023f, yPos, zPos+0.3f);//spawn within this range
            Instantiate(cabbageSeedPrefab, cabbageSeedSpawnPos, Quaternion.identity);// spawn cabbage seed



        }
    }
}
