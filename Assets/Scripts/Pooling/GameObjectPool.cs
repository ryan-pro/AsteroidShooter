using System.Linq;
using UnityEngine;

public class GameObjectPool : ObjectPool<GameObject>
{
    public GameObjectPool(GameObject prefabObject, Transform parent) : base(prefabObject, parent) { }

    public override void Populate(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            var newObject = Object.Instantiate(prefab);
            newObject.SetActive(false);
            pool.Add(newObject);
        }
    }

    public override GameObject GetObject()
    {
        var unused = pool.Find(a => !a.activeSelf);

        if(unused != null)
            return unused;

        var newObject = Object.Instantiate(prefab);
        newObject.SetActive(false);
        newObject.transform.SetParent(parent);

        pool.Add(newObject);
        return newObject;
    }

    public override int GetActiveObjectCount() => pool.Count(a => a.activeSelf);
}
