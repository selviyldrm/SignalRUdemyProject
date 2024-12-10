using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse(); //okunmayan bildirimlerin sayısını gösterecek
        List<Notification> GetAllNotificationByFalse(); //okunmayan bildirimlerin listesi
        void NotificationStatusChangeToFalse(int id); //bildirim durumunu false yap
        void NotificationStatusChangeToTrue(int id); //bildirim durumunu true yap
	}
}
