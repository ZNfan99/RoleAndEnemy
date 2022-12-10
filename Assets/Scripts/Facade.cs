using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 外观模式
/// </summary>
public class Facade
{
    //简单单例
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

    //角色系统
    private CharacterSystem m_CharacterSystem = null;
    //攻击按钮UI
    private AttackBtnUI m_AttackBtnUI = null;
    private TipsUI m_TipsUI = null;

    //初始化
    public void Initialize()
    {
        m_CharacterSystem = new CharacterSystem(this);
        m_AttackBtnUI = new AttackBtnUI(this);
        m_TipsUI = new TipsUI(this);
        CreatePlayer();
        CreateEnemy();
        m_CharacterSystem.SetTarget();
    }
    
    //创建敌人
    private void CreateEnemy()
    {
        ICharacterFactory Factory = FacadeFactory.GetCharacterFactory();
        Factory.CreateEnemy((EnemyType)DataCenter.currentEnemyID,
            (WeaponType)DataCenter.currentEnemyWeaponID,new Vector3(3,0,0));
    }
    
    //创建玩家
    private void CreatePlayer()
    {
        ICharacterFactory Factory = FacadeFactory.GetCharacterFactory();
        Factory.CreatePlayer((PlayerType)DataCenter.currentPlayerID,
            (WeaponType)DataCenter.currentPlayerWeaponID, 1,new Vector3(-3,0,0));
    }

    //更新
    public void Update()
    {
        if(m_CharacterSystem!= null)
        {
            m_CharacterSystem.Update();
        }
    }

    //释放
    public void Release()
    {
        m_CharacterSystem.Release();
        m_AttackBtnUI.Release();
        m_TipsUI.Release();
    }

    //设置玩家
    internal void AddPlayer(IPlayer player)
    {
        m_CharacterSystem.SetPlayer(player);
    }

    //设置敌人
    internal void AddEnemy(IEnemy enemy)
    {
       m_CharacterSystem.SetEnemy(enemy);
    }
}