using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¿ªÊ¼³¡¾°
/// </summary>
public class StartSceneState : SceneState
{
    public StartSceneState(SceneController controller) : base(controller)
    {
        this.m_stateID = StateID.StartState;
    }

    public override void Initialize()
    {
        
    }

    public override void Release()
    {
        
    }

    public override void Update()
    {
        m_sceneController.PerformTransition(Transition.CheckComplete);
    }
}
