using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    Vector3 nextEnemyCoordinates = new Vector3(0f, 4.33f, 197f);

    float nextEnemySpawn;

    readonly float nextEnemySpawnMax = 1f;

    readonly float nextEnemySpawnMin = 0.5f;

    readonly float nextEnemyXCoordinateMax = 7.77f;

    readonly float nextEnemyXCoordinateMin = 0.88f;

    GameObject[] pool;

    // Use this for initialization
    void Start()
    {
        this.PopulatePool();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.nextEnemySpawn > 0f)
        {
            this.nextEnemySpawn -= Time.deltaTime;
        }
        else
        {
            this.SpawnNextEnemy();
        }
    }

    void PopulatePool()
    {
        int count = this.transform.childCount;
        this.pool = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            this.pool[i] = this.transform.GetChild(i).gameObject;
        }
    }

    GameObject GetNextFreeItemFromPool()
    {
        int count = this.pool.Length;
        for (int i = 0; i < count; i++)
        {
            if (!this.pool[i].activeSelf)
            {
                GameObject item = this.pool[i];
                item.SetActive(true);
                item.transform.localScale = Vector3.one;
                return item;
            }
        }

        Debug.Log("No free items in the pool");
        return null;
    }

    void SpawnNextEnemy()
    {
        GameObject nextEnemyGO = this.GetNextFreeItemFromPool();

        if (nextEnemyGO == null)
        {
            return;
        }

        //7. Направете раждането на противников самолет да става на кординати(Vector3), 
        //в които компонента Х да е на случаен принцип между float nextEnemyXCoordinateMin = 0.88f; 
        //float nextEnemyXCoordinateMax = 7.77f;
        this.nextEnemyCoordinates.x = Random.Range(this.nextEnemyXCoordinateMin, this.nextEnemyXCoordinateMax);

        this.nextEnemySpawn = Random.Range(this.nextEnemySpawnMin, this.nextEnemySpawnMax);
        nextEnemyGO.SetActive(true);
        nextEnemyGO.transform.position = this.nextEnemyCoordinates;
    }
}