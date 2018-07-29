using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class HelloWorldSystem : IInitializeSystem
{
    readonly GameContext mContext;

    public HelloWorldSystem(Contexts contexts)
    {
        mContext = contexts.game;
    }

    public void Initialize()
    {
        mContext.CreateEntity().AddDebugMessage("Hello World!!!!!");
    }
}
