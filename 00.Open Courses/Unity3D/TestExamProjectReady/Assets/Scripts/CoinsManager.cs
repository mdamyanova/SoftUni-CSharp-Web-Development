using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    Vector3 nextCoinCoordinates = new Vector3(0f, 4.33f, 197f);

    float nextCoinSpawn;

    //10. Направете така, че и двата типа монети да се генерират два пъти по рядко.
    readonly float nextCoinSpawnMax = 1f; //past - 0.5f

    readonly float nextCoinSpawnMin = 0.2f; //past - 0.1f

    readonly float nextCoinXCoordinateMax = 7.77f;

    readonly float nextCoinXCoordinateMin = 0.88f;

    GameObject[] pool;

    // Use this for initialization
    void Start()
    {
        this.PopulatePool();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.nextCoinSpawn > 0f)
        {
            this.nextCoinSpawn -= Time.deltaTime;
        }
        else
        {
            this.SpawnNextCoin();
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
                item.transform.localScale = new Vector3(0.5f, 0.02f, 0.5f);
                return item;
            }
        }

        Debug.Log("No free items in the pool");
        return null;
    }

    void SpawnNextCoin()
    {
        GameObject nextCoinGO = this.GetNextFreeItemFromPool();

        if (nextCoinGO == null)
        {
            return;
        }

        this.nextCoinCoordinates.x = Random.Range(this.nextCoinXCoordinateMin, this.nextCoinXCoordinateMax);
        this.nextCoinSpawn = Random.Range(this.nextCoinSpawnMin, this.nextCoinSpawnMax);
        nextCoinGO.SetActive(true);
        nextCoinGO.transform.position = this.nextCoinCoordinates;
    }
}