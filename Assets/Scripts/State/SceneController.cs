using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ����������
/// </summary>
public class SceneController 
{
    private Dictionary<StateID, SceneState> m_states = new Dictionary<StateID, SceneState>();

    private StateID m_currentStateID;
    private SceneState m_currentState;
    private bool m_bRunBegin = false;
    AsyncOperation async;
    public void Update()
    {
        if (async != null && !async.isDone)
        {
            return;
        }
        if (m_currentState != null && m_bRunBegin == false)
        {
            m_bRunBegin = true;
            m_currentState.Initialize();
        }
        if (m_currentState != null)
        {
            m_currentState.Update();
        }
    }

    public void Release()
    {
        m_currentState.Release();
    }

    public void AddState(SceneState state)
    {
        if (state == null)
        {
            Debug.LogError("State����Ϊ��"); return;
        }
        if (m_currentState == null)
        {
            m_currentState = state;
            m_currentStateID = state.ID;
        }
        if (m_states.ContainsKey(state.ID))
        {
            Debug.LogError("״̬" + state.ID + "�Ѿ����ڣ��޷��ظ����"); return;
        }
        m_states.Add(state.ID, state);
    }

    public void RemoveState(StateID id)
    {
        if (id == StateID.NullStateID)
        {
            Debug.LogError("�޷�ɾ����״̬"); return;
        }
        if (m_states.ContainsKey(id) == false)
        {
            Debug.LogError("�޷�ɾ�������ڵ�״̬��" + id); return;
        }
        m_states.Remove(id);
    }

    public void PerformTransition(Transition transition)
    {
        if (transition == Transition.NullTransition)
        {
            Debug.LogError("�޷�ִ�пյ�ת������"); return;
        }
        StateID id = m_currentState.GetOutputState(transition);
        if (id == StateID.NullStateID)
        {
            Debug.LogWarning("��ǰ״̬" + m_currentStateID + "�޷�����ת������" + transition + "����ת��"); return;
        }
        if (m_states.ContainsKey(id) == false)
        {
            Debug.LogError("��״̬�����治����״̬" + id + "���޷�����״̬ת����"); return;
        }
        m_bRunBegin = false;
        // ���볡��
        async = SceneManager.LoadSceneAsync((int)id - 1);
        if (m_currentState != null)
            m_currentState.Release();
        SceneState state = m_states[id];
        m_currentState = state;
        m_currentStateID = id;
    }
}
