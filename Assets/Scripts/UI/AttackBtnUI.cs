using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBtnUI : IUserInterface,IObserver
{
    private Button m_BtnAttack = null;
    private Text m_TxtNum = null;
    private int m_Num = 0;
    public AttackBtnUI(Facade facade) : base(facade)
    {
        Initialize();
    }

    public void HandleNotification(string key, Notification notification)
    {
        switch (key)
        {
            case EventOrder.BTNACTIVE:
                m_BtnAttack.interactable = true;
                break;
            default:
                break;
        }
    }

    public override void Initialize()
    {
        m_RootUI = UITool.FindUIGameObject("Canvas");

        m_BtnAttack = UITool.GetUIComponent<Button>(m_RootUI, "BtnAttack");
        m_TxtNum = UITool.GetUIComponent<Text>(m_RootUI, "TxtNum");
        m_BtnAttack.onClick.AddListener(OnAttackBtnCb);
        MessageCenterByObserver.Instance().AddMessage(listNotification(), this);
    }

    public List<string> listNotification()
    {
        List<string> strings = new List<string>();
        strings.Add(EventOrder.BTNACTIVE);
        return strings;
    }

    private void OnAttackBtnCb()
    {
        Debug.Log("点击按钮");
        m_Num++;
        m_TxtNum.text = "第" + m_Num + "回合";
        m_BtnAttack.interactable = false;
        MessageCenterByObserver.Instance().NotifyObserver(EventOrder.PLAYERATTACK, null);
    }

    public override void Release()
    {
        MessageCenterByObserver.Instance().RemoveMessage(listNotification(), this);
         m_BtnAttack = null;
         m_TxtNum = null;
         m_Num = 0;
    }
}
