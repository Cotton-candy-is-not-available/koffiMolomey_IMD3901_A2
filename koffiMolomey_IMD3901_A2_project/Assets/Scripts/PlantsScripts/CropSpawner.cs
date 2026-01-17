using UnityEngine;

public class CropSpawner : MonoBehaviour
{
    //SeedManager seedManager;
    public Vector3 lastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = new Vector3(0,0,0);
    }


    public void SpawCrop(GameObject cropPrefab)
    {
        Instantiate(cropPrefab, lastPosition, Quaternion.identity);
    }



}
