using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class AddViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform mViewContainer = new GameObject("Game Views").transform;
    readonly GameContext mContext;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        mContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity item in entities)
        {
            var go = new GameObject("Game View");
            go.transform.SetParent(mViewContainer, false);
            item.AddView(go);
            go.Link(item, mContext);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && !entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }
}
