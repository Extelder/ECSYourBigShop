using Leopotam.Ecs;
using UnityEngine;

sealed class StackBlocksGeneratorSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<StackBlockGeneratorComponent> generatorFilter = null;

    public void Run()
    {
        foreach (var i in generatorFilter)
        {
            ref var stackBlockGeneratorComponent = ref generatorFilter.Get1(i);
            ref var currentGenerateDelay = ref stackBlockGeneratorComponent.currentGenerateDelay;

            currentGenerateDelay -= Time.deltaTime;
            if (currentGenerateDelay <= 0)
            {
                StackObject stackObject = Object.Instantiate(stackBlockGeneratorComponent.stackObjectPrefab,
                    stackBlockGeneratorComponent.generatePlace.position, Quaternion.identity);
                stackObject.Drop();
                currentGenerateDelay = stackBlockGeneratorComponent.generateDelay;
            }
        }
    }

    public void Init()
    {
        foreach (var i in generatorFilter)
        {
            ref var stackBlockGeneratorComponent = ref generatorFilter.Get1(i);
            ref var currentGenerateDelay = ref stackBlockGeneratorComponent.currentGenerateDelay;
            currentGenerateDelay = stackBlockGeneratorComponent.generateDelay;
        }
    }
}