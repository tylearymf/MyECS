using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MovementSystems : Feature
{
    public MovementSystems(Contexts contexts) : base("Movement Systems")
    {
        Add(new MoveSystem(contexts));
    }
}
