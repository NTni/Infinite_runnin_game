using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] TilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    [SerializeField]
    private float tileLength ;
    [SerializeField]
    private int amnofTilesonScreen ;
    private List<GameObject> ActiveTiles;
    private float safeZone = 15.0f;
    private int lastPrefabIndex = 0;

    void Start()
    {
        ActiveTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnofTilesonScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - amnofTilesonScreen*tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(TilePrefabs[RandomPrefabIndex()] as GameObject);
        else
            go = Instantiate(TilePrefabs[prefabIndex] as GameObject);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        ActiveTiles.Add(go);
    }
    void DeleteTile()
    {
        Destroy(ActiveTiles[0]);
        ActiveTiles.RemoveAt(0);
    }

    int RandomPrefabIndex()
    {
        if (TilePrefabs.Length <= 1)
            return 0;

        int RandomIndex = lastPrefabIndex;
        while(RandomIndex==lastPrefabIndex)
        {
            RandomIndex = Random.Range(0, TilePrefabs.Length);
        }
        lastPrefabIndex = RandomIndex;
        return RandomIndex;
    }
}
