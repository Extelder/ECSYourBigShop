using Leopotam.Ecs;
using UnityEngine;

sealed class RemoveOutStackObjectSystem : IEcsRunSystem
{
    private readonly EcsFilter<RemoveObjectOutStackEvent> stackeventFilter = null;
    private readonly EcsFilter<StackComponent, PlayerTag> stackFilter = null;

    public void Run()
    {
        foreach (var i in stackeventFilter)
        {
            ref var entity = ref stackeventFilter.GetEntity(i);

            Debug.Log("Remove");
            foreach (var j in stackFilter)
            {
                ref var stack = ref stackFilter.Get1(j);

                if (stack.numberOfObjects >= 1)
                {
                    StackObject lastStackObject = stack.objectsInStack[stack.objectsInStack.Count - 1];
                    Transform lastStackObjectTransform = lastStackObject.transform;
                    lastStackObject.Drop();
                    lastStackObjectTransform.position += lastStackObjectTransform.rotation * stack.dropMoveOffset;
                    lastStackObjectTransform.SetParent(null);
                    stack.objectsInStack.Remove(lastStackObject);
                    stack.numberOfObjects--;
                }

                entity.Del<RemoveObjectOutStackEvent>();
            }
        }
    }
}