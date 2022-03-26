using UnityEngine;

namespace Shooter.Gameplay
{
    [CreateAssetMenu(menuName = "Level Creation/New Level")]
    public class Level : IterableObjectCollection<LevelWave>
    {
        public override void Refresh()
        {
            foreach (var wave in objectList)
                wave.Refresh();
        }
    }
}