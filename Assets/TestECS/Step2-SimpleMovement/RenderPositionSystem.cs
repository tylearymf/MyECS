using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class RenderPositionSystem : ReactiveSystem<GameEntity>
{
    public RenderPositionSystem(Contexts contexts) : base(contexts.game) { }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity item in entities)
        {
            item.view.gameObject.transform.position = item.postion.value;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPostion && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Postion);
    }
}
