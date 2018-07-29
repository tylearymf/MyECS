using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    readonly InputContext mContext;
    InputEntity mLeftMouseEntity;
    InputEntity mRightMouseEntity;

    public EmitInputSystem(Contexts contexts)
    {
        mContext = contexts.input;
    }

    public void Execute()
    {
        var tMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            mLeftMouseEntity.ReplaceMouseDown(tMousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            mLeftMouseEntity.ReplaceMousePosition(tMousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            mLeftMouseEntity.ReplaceMouseUp(tMousePosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            mRightMouseEntity.ReplaceMouseDown(tMousePosition);
        }
        if (Input.GetMouseButton(1))
        {
            mRightMouseEntity.ReplaceMousePosition(tMousePosition);
        }
        if (Input.GetMouseButtonUp(1))
        {
            mRightMouseEntity.ReplaceMouseUp(tMousePosition);
        }
    }

    public void Initialize()
    {
        mContext.isLeftMouse = true;
        mLeftMouseEntity = mContext.leftMouseEntity;

        mContext.isRightMouse = true;
        mRightMouseEntity = mContext.rightMouseEntity;
    }
}
