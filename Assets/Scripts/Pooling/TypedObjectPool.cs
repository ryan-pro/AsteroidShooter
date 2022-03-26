using System.Linq;
using UnityEngine;

public class TypedObjectPool<T> : ObjectPool<T> where T : Component
{
    public TypedObjectPool(T prefabObject, Transform parent) : base(prefabObject, parent) { }

    public override void Populate(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var newObject = Object.Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            pool.Add(newObject);
        }
    }

    public override T GetObject()
    {
        var unused = pool.Find(a => !a.gameObject.activeSelf);

        if (unused != null)
            return unused;

        var newObject = Object.Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        newObject.transform.SetParent(parent);

        pool.Add(newObject);
        return newObject;
    }

    public override void DestroyAllObjects()
    {
        foreach (var obj in pool)
            Object.Destroy(obj.gameObject);

        pool.Clear();
    }

    public override int GetActiveObjectCount() => pool.Count(a => a.gameObject.activeSelf);
}
