using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    [SerializeField] PoolableObject prefab;
    [SerializeField] int initialAmount = 100;

    Stack<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
        pooledObjects = new Stack<GameObject>();

        for (int i = 0; i < initialAmount; i++)
        {
            AddObjectToPool();
        }

        Debug.LogFormat("Initialized Object Pool with {0} objects", pooledObjects.Count);
	}

    private GameObject AddObjectToPool()
    {
        PoolableObject newObject = Instantiate(prefab, transform);

        pooledObjects.Push(newObject.gameObject);

        newObject.gameObject.SetActive(false);

        newObject.Init(this);

        return newObject.gameObject;
    }

    public GameObject GetObjectFromPool()
    {
        if (pooledObjects.Count == 0)
        {
            AddObjectToPool();
        }

        return pooledObjects.Pop();
    }

    public void ReturnToPool(GameObject returningObject)
    {
        pooledObjects.Push(returningObject);
        returningObject.SetActive(false); // redundant
        returningObject.transform.SetParent(transform);
        returningObject.transform.localPosition = Vector3.zero;
        returningObject.transform.localRotation = Quaternion.identity;
    }

}
