using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IObserver
{
    List<string> listNotification();
    void HandleNotification(string key,Notification notification);
}

