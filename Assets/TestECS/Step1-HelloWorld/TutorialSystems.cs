using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class TutorialSystems : Feature
{
    public TutorialSystems(Contexts contexts) : base("教程系统")
    {
        Add(new HelloWorldSystem(contexts));
        Add(new DebugMessageSystem(contexts));
        Add(new LogMouseClickSystem(contexts));
    }
}
