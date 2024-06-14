using Leopotam.Ecs;
using UnityEngine;

public class RotationSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;

    private readonly EcsFilter<RotationComponent, JoystickInputComponent, TransformComponent, PlayerTag> rotationFilter = null;

    private Quaternion targetRotation;

    public void Run()
    {
        foreach (var i in rotationFilter)
        {
            ref var rotationComponent = ref rotationFilter.Get1(i);
            ref var joystickInputComponent = ref rotationFilter.Get2(i);
            ref var transformComponent = ref rotationFilter.Get3(i);

            ref var rigidbody = ref rotationComponent.rigidbody;
            ref var rotationSpeed = ref rotationComponent.rotationSpeed;
            ref var joystick = ref joystickInputComponent.joystick;
            ref var transform = ref transformComponent.transform;

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                targetRotation = Quaternion.LookRotation(rigidbody.velocity);
            }

            transform.rotation =
                Quaternion.LerpUnclamped(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}