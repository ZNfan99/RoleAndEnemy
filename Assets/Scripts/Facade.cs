using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���ģʽ
/// </summary>
public class Facade
{
    //�򵥵���
    private static Facade _instance;
    public static Facade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Facade();
            }
            return _instance;
        }
    }

    //��ɫϵͳ
    private CharacterSystem m_CharacterSystem = null;
    //������ťUI
    private AttackBtnUI m_AttackBtnUI = null;
    private TipsUI m_TipsUI = null;

    //��ʼ��
    public void Initialize()
    {
        m_CharacterSystem = new CharacterSystem(this);
        m_AttackBtnUI = new AttackBtnUI(this);
        m_TipsUI = new TipsUI(this);
        CreatePlayer();
        CreateEnemy();
        m_CharacterSystem.SetTarget();
    }
    
    //��������
    private void CreateEnemy()
    {
        ICharacterFactory Factory = FacadeFactory.GetCharacterFactory();
        Factory.CreateEnemy((EnemyType)DataCenter.currentEnemyID,
            (WeaponType)DataCenter.currentEnemyWeaponID,new Vector3(3,0,0));
    }
    
    //�������
    private void CreatePlayer()
    {
        ICharacterFactory Factory = FacadeFactory.GetCharacterFactory();
        Factory.CreatePlayer((PlayerType)DataCenter.currentPlayerID,
            (WeaponType)DataCenter.currentPlayerWeaponID, 1,new Vector3(-3,0,0));
    }

    //����
    public void Update()
    {
        if(m_CharacterSystem!= null)
        {
            m_CharacterSystem.Update();
        }
    }

    //�ͷ�
    public void Release()
    {
        m_CharacterSystem.Release();
        m_AttackBtnUI.Release();
        m_TipsUI.Release();
    }

    //�������
    internal void AddPlayer(IPlayer player)
    {
        m_CharacterSystem.SetPlayer(player);
    }

    //���õ���
    internal void AddEnemy(IEnemy enemy)
    {
       m_CharacterSystem.SetEnemy(enemy);
    }
}