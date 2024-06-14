using System;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public sealed class EcsGameStartup : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;

    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems.ConvertScene();

        AddInjections();
        AddOneFrame();
        AddSystems();

        systems.Init();
    }

    private void Update()
    {
        Debug.Log(systems);
        Debug.Log(world);
        systems.Run();
    }

    private void AddSystems()
    {
        systems
            .Add(new PlayerInputSystem())
            .Add(new MovementSystem())
            .Add(new StackBlocksGeneratorSystem())
            .Add(new RotationSystem())
            .Add(new StickmanMovementAnimationSystem())
            .Add(new AddToStackObjectSystem())
            .Add(new RemoveOutStackObjectSystem())
            ;
    }

    private void AddInjections()
    {
    }

    private void AddOneFrame()
    {
        
    }


    private void OnDestroy()
    {
        if (systems == null) return;

        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;
    }
    
    
}