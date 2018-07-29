using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveSystem : IExecuteSystem, ICleanupSystem
{
    readonly IGroup<GameEntity> mMoves;
    readonly IGroup<GameEntity> mMoveCompletes;
    const float cSpeed = 4F;

    public MoveSystem(Contexts contexts)
    {
        mMoves = contexts.game.GetGroup(GameMatcher.Move);
        mMoveCompletes = contexts.game.GetGroup(GameMatcher.MoveComplete);
    }

    public void Cleanup()
    {
        foreach (var item in mMoveCompletes.GetEntities())
        {
            item.isMoveComplete = false;
        }
        Debug.Log("MoveSystem Cleanup");
    }

    public void Execute()
    {
        foreach (var item in mMoves.GetEntities())
        {
            var tDireaction = item.move.target - item.postion.value;
            var tNewPosition = item.postion.value + tDireaction.normalized * cSpeed * Time.deltaTime;
            item.ReplacePostion(tNewPosition);

            var tAngle = Mathf.Atan2(tDireaction.y, tDireaction.x) * Mathf.Rad2Deg;
            item.ReplaceDirection(tAngle);

            var tDistance = tDireaction.magnitude;
            if (tDistance <= 0.5F)
            {
                item.RemoveMove();
                item.isMoveComplete = true;
            }
        }
    }
}
