using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Generic class for pooling game objects.
/// </summary>
public abstract class ObjectPool<T> where T : Object
{
    protected T prefab;
    protected Transform parent;
    protected readonly List<T> pool = new List<T>();

    protected ObjectPool(T prefabObject, Transform parent)
    {
        prefab = prefabObject;
        this.parent = parent;
    }

    public abstract void Populate(int amount);
    public abstract T GetObject();

    public abstract int GetActiveObjectCount();

    public virtual void DestroyAllObjects()
    {
        foreach (var obj in pool)
            Object.Destroy(obj);

        pool.Clear();
    }
}
