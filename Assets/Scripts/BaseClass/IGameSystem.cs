using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ϸϵͳ�Ľӿ�
/// </summary>
public abstract class IGameSystem
{
    public Facade m_Facade = null;

    public IGameSystem(Facade facade)
    {
        m_Facade = facade;
    }

    public virtual void Initialize() { }//��ʼ��
    public virtual void Release() { }//�ͷ�
    public virtual void Update() { }//����
}
