using Leopotam.Ecs;
using UnityEngine;

sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;

    private readonly EcsFilter<MovableComponent, DirectionComponent> movableFilter = null;

    public void Run()
    {
        foreach (var i in movableFilter)
        {
            ref var movableComponent = ref movableFilter.Get1(i);
            ref var directionComponent = ref movableFilter.Get2(i);

            ref var rigidbody = ref movableComponent.rigidbody;
            ref var speed = ref movableComponent.moveSpeed;
            ref var direction = ref directionComponent.Direction;

            rigidbody.velocity = new Vector3(direction.x * speed, rigidbody.velocity.y, direction.y * speed);

        }
    }
}