using UnityEngine;
using System.Collections;

public class PoolManager : MonoBehaviour 
{
    GameObject[] pool;
    Transform myTransform;
    Camera mainCam;

	// Use this for initialization
	void Start ()
    {
        mainCam = Camera.main;
        myTransform = transform;
        int count = myTransform.childCount;
        pool = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            pool[i] = myTransform.GetChild(i).gameObject;
        }
	}

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "poolItem")
                {
                    hit.transform.parent = myTransform;
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject poolItem = GetNextFreeItemFromPool();

            if (poolItem != null)
            {
                poolItem.transform.position = Vector3.zero;
                poolItem.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-45f, 45f));
                poolItem.GetComponent<Rigidbody>().AddRelativeForce(0f, 500f, 0f);
            }
        }
	}

    GameObject GetNextFreeItemFromPool()
    {
        int count = pool.Length;
        for (int i = 0; i < count; i++)
        {
            if (!pool[i].activeSelf)
            {
                GameObject item = pool[i];
                item.transform.parent = null;
                item.SetActive(true);
                item.transform.localScale = Vector3.one;
                return item;
            }
        }

        Debug.Log("No free items in the pool");
        return null;
    }
}
