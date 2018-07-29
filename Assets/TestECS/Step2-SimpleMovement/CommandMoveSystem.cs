using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CommandMoveSystem : ReactiveSystem<InputEntity>, ICleanupSystem
{
    readonly IGroup<GameEntity> mMovers;

    public CommandMoveSystem(Contexts contexts) : base(contexts.input)
    {
        mMovers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Mover));//.NoneOf(GameMatcher.Move));
    }

    public void Cleanup()
    {
        foreach (var item in mMovers)
        {
            item.Destroy();
        }
        Debug.Log("CommandMoveSystem Cleanup");
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity item in entities)
        {
            var tMovers = mMovers.GetEntities();
            if (tMovers.Length == 0) return;

            //tMovers[Random.Range(0, tMovers.Length)].ReplaceMove(item.mouseDown.position);

            foreach (var tMove in tMovers)
            {
                tMove.ReplaceMove(item.mouseDown.position);
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));
    }
}
