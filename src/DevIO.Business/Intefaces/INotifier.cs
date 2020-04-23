using System.Collections.Generic;
using DevIO.Business.Notificacoes;

namespace DevIO.Business.Intefaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}