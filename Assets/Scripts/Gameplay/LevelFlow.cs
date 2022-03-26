using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shooter.Gameplay
{
    public class LevelFlow : MonoBehaviour
    {
        [Header("Instruction Handlers")]
        [SerializeField]
        private SpawnHandler spawnHandler;
        [SerializeField]
        private WaitHandler waitHandler;
        [SerializeField]
        private WaitForClearHandler clearHandler;
        [Space]

        [SerializeField]
        private Level[] levelList;

        [SerializeField]
        private UnityEvent onLevelCompleted;

        [System.NonSerialized]
        private int listIndex;

        private Dictionary<System.Type, IInstructionHandler> handlerMap;

        private void OnDisable()
        {
            foreach (var level in levelList)
                level.Refresh();

            listIndex = 0;
        }

        private void PopulateMap()
        {
            handlerMap = new Dictionary<System.Type, IInstructionHandler>()
            {
                { typeof(SpawnInstruction), spawnHandler },
                { typeof(WaitInstruction), waitHandler },
                { typeof(WaitForClearInstruction), clearHandler }
            };
        }

        public bool TryPlayNextLevel()
        {
            if (listIndex < 0 || listIndex >= levelList.Length)
                return false;

            if (handlerMap == null)
                PopulateMap();

            StartCoroutine(ProcessLevelInstructions());

            listIndex++;
            return true;
        }

        private IEnumerator ProcessLevelInstructions()
        {
            var level = levelList[listIndex];

            while (level.TryGetNext(out var wave))
            {
                while (wave.TryGetNext(out var data))
                {
                    var handler = handlerMap[data.Instruction.InstructionType];
                    yield return StartCoroutine(handler.ProcessInstruction(data));
                }
            }

            onLevelCompleted.Invoke();
        }

        public void DisposeHandlerObjects()
        {
            foreach (var handler in handlerMap.Values)
                handler.CleanUp();
        }
    }
}