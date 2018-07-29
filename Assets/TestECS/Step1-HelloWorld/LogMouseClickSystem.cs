using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class LogMouseClickSystem : IExecuteSystem
{
    readonly GameContext mContext;

    public LogMouseClickSystem(Contexts contexts)
    {
        mContext = contexts.game;
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mContext.CreateEntity().AddDebugMessage("鼠标左击");
        }
        if (Input.GetMouseButtonUp(1))
        {
            mContext.CreateEntity().AddDebugMessage("鼠标右击");
        }
    }
}
