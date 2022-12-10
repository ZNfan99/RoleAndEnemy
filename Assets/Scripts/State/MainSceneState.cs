using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneState : SceneState
{
    Button btnRole1;
    Button btnRole2;
    Button btnEnemy1;
    Button btnEnemy2;
    Button btnPlayerWeapon1;
    Button btnPlayerWeapon2;
    Button btnPlayerWeapon3;
    Button btnEnemyWeapon1;
    Button btnEnemyWeapon2;
    Button btnEnemyWeapon3;
    public MainSceneState(SceneController controller) : base(controller)
    {
        this.m_stateID = StateID.MainState;
    }

    public override void Initialize()
    {
         btnRole1 = GameObject.Find("Canvas/Panel/RoleRoot/BtnRole1").GetComponent<Button>();
         btnRole2 = GameObject.Find("Canvas/Panel/RoleRoot/BtnRole2").GetComponent<Button>();
         btnEnemy1 = GameObject.Find("Canvas/Panel/EnemyRoot/BtnEnemy1").GetComponent<Button>();
         btnEnemy2 = GameObject.Find("Canvas/Panel/EnemyRoot/BtnEnemy2").GetComponent<Button>();
         btnPlayerWeapon1 = GameObject.Find("Canvas/Panel/RoleWeaponRoot/BtnWeapon1").GetComponent<Button>();
         btnPlayerWeapon2 = GameObject.Find("Canvas/Panel/RoleWeaponRoot/BtnWeapon2").GetComponent<Button>();
         btnPlayerWeapon3 = GameObject.Find("Canvas/Panel/RoleWeaponRoot/BtnWeapon3").GetComponent<Button>();
         btnEnemyWeapon1 = GameObject.Find("Canvas/Panel/EnemyWeaponRoot/BtnWeapon1").GetComponent<Button>();
         btnEnemyWeapon2 = GameObject.Find("Canvas/Panel/EnemyWeaponRoot/BtnWeapon2").GetComponent<Button>();
         btnEnemyWeapon3 = GameObject.Find("Canvas/Panel/EnemyWeaponRoot/BtnWeapon3").GetComponent<Button>();
        

        btnRole1.onClick.AddListener(OnbtnRole1);
        btnRole2.onClick.AddListener(OnbtnRole2);
        btnEnemy1.onClick.AddListener(OnbtnEnemy1);
        btnEnemy2.onClick.AddListener(OnbtnEnemy2);
        btnPlayerWeapon1.onClick.AddListener(OnbtnPlayerWeapon1);
        btnPlayerWeapon2.onClick.AddListener(OnbtnPlayerWeapon2);
        btnPlayerWeapon3.onClick.AddListener(OnbtnPlayerWeapon3);
        btnEnemyWeapon1.onClick.AddListener(OnbtnEnemyWeapon1);
        btnEnemyWeapon2.onClick.AddListener(OnbtnEnemyWeapon2);
        btnEnemyWeapon3.onClick.AddListener(OnbtnEnemyWeapon3);

        Button btnLoginBattle = GameObject.Find("Canvas/Panel/BtnLoginBattle").GetComponent<Button>();
        btnLoginBattle.onClick.AddListener(OnbtnLoginBattle);
    }

    private void OnbtnLoginBattle()
    {
        if(DataCenter.currentEnemyID != 0 && DataCenter.currentEnemyWeaponID != 0 &&
            DataCenter.currentPlayerID != 0 && DataCenter.currentPlayerWeaponID != 0)
        {
            m_sceneController.PerformTransition(Transition.OnClickBattle);
        }
        else
        {
            Debug.Log("Î´Ñ¡Ôñ");
        }
       
    }

    private void OnbtnEnemyWeapon3()
    {
        DataCenter.currentEnemyWeaponID = 3;
    }

    private void OnbtnEnemyWeapon2()
    {
        DataCenter.currentEnemyWeaponID = 2;
    }

    private void OnbtnEnemyWeapon1()
    {
        DataCenter.currentEnemyWeaponID = 1;
    }

    private void OnbtnPlayerWeapon3()
    {
        DataCenter.currentPlayerWeaponID = 3;
    }

    private void OnbtnPlayerWeapon2()
    {
        DataCenter.currentPlayerWeaponID = 2;
    }

    private void OnbtnPlayerWeapon1()
    {
        DataCenter.currentPlayerWeaponID = 1;
    }

    private void OnbtnEnemy2()
    {
        DataCenter.currentEnemyID = 2;
    }

    private void OnbtnEnemy1()
    {
        DataCenter.currentEnemyID = 1;
    }

    private void OnbtnRole2()
    {
        DataCenter.currentPlayerID = 2;
    }

    private void OnbtnRole1()
    {
        DataCenter.currentPlayerID = 1;
    }

    public override void Release()
    {
        btnRole1 = null;
        btnRole2 = null;
        btnEnemy1 = null;
        btnEnemy2 = null;
        btnPlayerWeapon1 = null;
        btnPlayerWeapon2 = null;
        btnPlayerWeapon3 = null;
        btnEnemyWeapon1 = null;
        btnEnemyWeapon2 = null;
        btnEnemyWeapon3 = null;
    }

    public override void Update()
    {
        
    }
}
