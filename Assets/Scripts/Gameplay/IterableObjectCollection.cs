using UnityEngine;

namespace Shooter.Gameplay
{
    public abstract class IterableObjectCollection<T> : ScriptableObject
    {
        [SerializeField]
        protected T[] objectList;

        [System.NonSerialized]
        protected int listIndex;

        public virtual bool TryGetNext(out T nextObject)
        {
            nextObject = default;

            if (listIndex < 0 || listIndex >= objectList.Length)
            {
                listIndex = 0;
                return false;
            }

            nextObject = objectList[listIndex++];
            return true;
        }

        public abstract void Refresh();
    }
}