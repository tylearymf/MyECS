using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class RenderDirectionSystem : ReactiveSystem<GameEntity>
{
    public RenderDirectionSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity item in entities)
        {
            var tAngle = item.direction.value;
            item.view.gameObject.transform.rotation = Quaternion.AngleAxis(tAngle - 90, Vector3.forward);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDirection && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Direction);
    }
}
