using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsUI : IUserInterface,IObserver
{
    public GameObject m_Tips = null;
    public Button m_BtnReturn = null;
    public Text m_TxtEnding = null;

    public TipsUI(Facade facade) : base(facade)
    {
        Initialize();
    }
    public override void Initialize()
    {
        m_Tips = UITool.FindUIGameObject("Tips");
        m_BtnReturn = UITool.GetUIComponent<Button>(m_Tips, "BtnReturn");
        m_TxtEnding = UITool.GetUIComponent<Text>(m_Tips, "TxtEnding");
        m_Tips.SetActive(false);
        MessageCenterByObserver.Instance().AddMessage(listNotification(), this);
        m_BtnReturn.onClick.AddListener(OnBtnReturnCb);
    }

    private void OnBtnReturnCb()
    {
        MessageCenterByObserver.Instance().NotifyObserver(EventOrder.GAMERETURN, null);
    }

    public void HandleNotification(string key, Notification notification)
    {
        switch (key)
        {
            case EventOrder.GAMEENDING:
                m_Tips.SetActive(true);
                Time.timeScale = 0;
                m_TxtEnding.text = notification.data[0].ToString();
                break;
            default:
                break;
        }
    }

    public List<string> listNotification()
    {
        List<string> list = new List<string>();
        list.Add(EventOrder.GAMEENDING);
        return list;
    }

    public override void Release()
    {
        MessageCenterByObserver.Instance().RemoveMessage(listNotification(), this);
    }
}
