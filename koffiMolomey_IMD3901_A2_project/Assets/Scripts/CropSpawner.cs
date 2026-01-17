using UnityEngine;

public class CropSpawner : MonoBehaviour
{

    public GameObject cropPrefab;

    SeedManager seedManager;
    public Vector3 lastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPosition != null)
        {
            SpawCrop();//spawn new crop when position is not null

        }
    }



    public void SpawCrop()
    {
        Instantiate(cropPrefab, lastPosition, Quaternion.identity);
    }



}
