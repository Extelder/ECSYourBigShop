using Leopotam.Ecs;

sealed class PlayerInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<DirectionComponent, JoystickInputComponent, PlayerTag> directionFilter = null;

    public void Run()
    {
        foreach (var i in directionFilter)
        {
            ref var directionComponent = ref directionFilter.Get1(i);
            ref var joystickComponent = ref directionFilter.Get2(i);
            ref var direction = ref directionComponent.Direction;

            direction.x = joystickComponent.joystick.Horizontal;
            direction.y = joystickComponent.joystick.Vertical;
        }
    }
}