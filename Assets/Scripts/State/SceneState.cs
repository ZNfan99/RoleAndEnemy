using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��������
/// </summary>
public enum Transition
{
    NullTransition = 0,//null
    CheckComplete,//����
    OnClickBattle,
    Exit//�˳�
}
/// <summary>
/// ״̬ID
/// </summary>
public enum StateID
{
    NullStateID = 0,
    StartState = 1,
    MainState =2,
    BattleState
}
/// <summary>
/// �����Ļ���
/// </summary>
public abstract class SceneState
{
    protected StateID m_stateID;//״̬ID
    public StateID ID
    {
        get { return m_stateID; }
    }
    //��������״̬������״̬�ı�Ŀ�
    Dictionary<Transition, StateID> m_stateMaps = new Dictionary<Transition, StateID>();
    //���������еĳ���������
    protected SceneController m_sceneController = null;

    //���캯�����ڹ����ʱ����и�ֵ����
    public SceneState(SceneController controller)
    {
        m_sceneController = controller;
    }
    //�����������
    public void AddTransition(Transition transition,StateID stateID)
    {
        if(transition == Transition.NullTransition)
        {
            Debug.LogError("������NullTransition"); return;
        }
        if (stateID == StateID.NullStateID)
        {
            Debug.LogError("������NullStateID"); return;
        }
        if (m_stateMaps.ContainsKey(transition))
        {
            Debug.LogError("���ת��������ʱ��" + transition + "�Ѿ�������map��"); return;
        }
        m_stateMaps.Add(transition, stateID);
    }
    //���ɾ������
    public void RemoveTransition(Transition transition)
    {
        if (transition == Transition.NullTransition)
        {
            Debug.LogError("������NullTransition"); return;
        }
        if (!m_stateMaps.ContainsKey(transition))
        {
            Debug.LogError("ɾ��ת��������ʱ��" + transition + "��������map��"); return;
        }
        m_stateMaps.Remove(transition);
    }
    //ͨ��ת��������ȡ��Ҫ��ת������ID
    public StateID GetOutputState(Transition transition)
    {
        if (m_stateMaps.ContainsKey(transition))
        {
            return m_stateMaps[transition];
        }
        return StateID.NullStateID;
    }
    //��ʼ��
    public abstract void Initialize();
    //����
    public abstract void Update();
    //�ͷ�
    public abstract void Release();
}