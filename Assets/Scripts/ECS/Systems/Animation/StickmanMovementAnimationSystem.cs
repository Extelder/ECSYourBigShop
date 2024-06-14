using Leopotam.Ecs;

sealed class StickmanMovementAnimationSystem : IEcsRunSystem
{
    private readonly EcsFilter<JoystickInputComponent, AnimatorComponent, StickmanAnimationComponent, PlayerTag> animationFilter =
        null;

    public void Run()
    {
        foreach (var i in animationFilter)
        {
            ref var joystickComponent = ref animationFilter.Get1(i);
            ref var animatorComponent = ref animationFilter.Get2(i);
            ref var animationComponent = ref animationFilter.Get3(i);

            var input = joystickComponent.joystick.Direction;
            ref var animator = ref animatorComponent.animator;

            string runAnimationBoolName = animationComponent.runAnimationBoolName;

            if (input.x != 0 || input.y != 0)
            {
                animator.SetBool(runAnimationBoolName, true);
            }
            else
            {
                animator.SetBool(runAnimationBoolName, false);
            }
        }
    }
}