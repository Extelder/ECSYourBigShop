using Leopotam.Ecs;
using UnityEngine;

sealed class AddToStackObjectSystem : IEcsRunSystem
{
    private readonly EcsFilter<AddObjectInStackEvent> stackeventFilter = null;
    private readonly EcsFilter<StackComponent, PlayerTag> stackFilter = null;

    public void Run()
    {
        foreach (var i in stackeventFilter)
        {
            ref var entity = ref stackeventFilter.GetEntity(i);
            ref var AddObjectToStack = ref stackeventFilter.Get1(i);

            ref var stackObject = ref AddObjectToStack.StackObject;
            var stackObjectTransform = stackObject.transform;


            foreach (var j in stackFilter)
            {
                ref var stack = ref stackFilter.Get1(j);

                stack.numberOfObjects++;

                stackObject.Pickup();

                stackObjectTransform.SetParent(stack.stackStartPlace);

                stackObjectTransform.localPosition
                    = new Vector3
                    (0,
                        0 + stack.stackPadding * stack.numberOfObjects,
                        0);

                stack.objectsInStack.Add(stackObject);

                stackObjectTransform.localEulerAngles = Vector3.zero;


                entity.Del<AddObjectInStackEvent>();
            }
        }
    }
}