using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI����Ľӿ�
/// </summary>
public abstract class IUserInterface
{
    public Facade m_Facade = null;
    public GameObject m_RootUI = null;

    public IUserInterface(Facade facade) 
    {
        m_Facade= facade;
    }

    public virtual void Initialize() { }//��ʼ��
    public virtual void Release() { }//�ͷ�
    public virtual void Update() { }//����
}