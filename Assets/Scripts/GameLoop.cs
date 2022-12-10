using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    //�����Ĺ���
    SceneController m_sceneController;
    private void Awake()
    {
        //��ת������ɾ��
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //ʵ������Ӧ��Scene�����࣬����ÿ���Ŀ��м������Ӧ������
        m_sceneController = new SceneController();
        SceneState startState = new StartSceneState(m_sceneController);
        startState.AddTransition(Transition.CheckComplete, StateID.MainState);
        SceneState mainState = new MainSceneState(m_sceneController);
        mainState.AddTransition(Transition.OnClickBattle, StateID.BattleState);
        SceneState battleState = new BattleSceneState(m_sceneController);
        battleState.AddTransition(Transition.Exit, StateID.MainState);
       

        m_sceneController.AddState(startState);
        m_sceneController.AddState(mainState);
        m_sceneController.AddState(battleState);
    }

    // Update is called once per frame
    void Update()
    {
        m_sceneController.Update();
    }
}
