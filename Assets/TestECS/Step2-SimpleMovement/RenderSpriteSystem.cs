﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class RenderSpriteSystem : ReactiveSystem<GameEntity>
{
    public RenderSpriteSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity item in entities)
        {
            var go = item.view.gameObject;
            var sr = go.GetComponent<SpriteRenderer>();
            if (sr == null) sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>(item.sprite.name);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }
}