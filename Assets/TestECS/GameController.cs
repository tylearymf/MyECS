using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Systems mSetp1Systems;
    Systems mSetp2Systems;

    void Start()
    {
        //mSetp1Systems = new Feature("测试系统").Add(new TutorialSystems(Contexts.sharedInstance));
        //mSetp1Systems.Initialize();

        mSetp2Systems = new Feature("简单移动")
            .Add(new ViewSystems(Contexts.sharedInstance))
            .Add(new InputSystems(Contexts.sharedInstance))
            .Add(new MovementSystems(Contexts.sharedInstance));
        mSetp2Systems.Initialize();
    }

    void Update()
    {
        //mSetp1Systems.Execute();
        mSetp2Systems.Execute();
    }

    private void OnDestroy()
    {
        //mSetp2Systems.Cleanup();
    }

    [ContextMenu("TestDebug")]
    void TestDebug()
    {
        Contexts.sharedInstance.game.CreateEntity().AddDebugMessage("Hello World");
    }
}
