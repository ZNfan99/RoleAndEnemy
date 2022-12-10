using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Notification
{
    //消息类型
    public string msg;
    //存储消息的集合
    public object[] data;

    public void Refresh(string msg, params object[] data)
    {
        this.msg = msg;
        this.data = data;
    }
    public void Clear()
    {
        msg = string.Empty;
        data = null;
    }
}

