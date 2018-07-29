using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CreateMoverSystem : ReactiveSystem<InputEntity>
{
    readonly GameContext mContext;

    public CreateMoverSystem(Contexts contexts) : base(contexts.input)
    {
        mContext = contexts.game;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity item in entities)
        {
            var tMover = mContext.CreateEntity();
            tMover.isMover = true;
            tMover.AddPostion(item.mouseDown.position);
            tMover.AddDirection(Random.Range(0, 360));
            tMover.AddSprite("Bee");
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseDown));
    }
}
