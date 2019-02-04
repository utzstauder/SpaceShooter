using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour {

    ObjectPool objectPool;

    private void OnDisable()
    {
        if (objectPool == null) return;

        objectPool.ReturnToPool(gameObject);
    }

    public void Init(ObjectPool objectPool)
    {
        this.objectPool = objectPool;
    }
}
