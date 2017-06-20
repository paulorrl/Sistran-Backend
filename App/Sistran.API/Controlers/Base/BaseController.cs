using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Sistran.Kernel.Domain.DomainEvents;
using Sistran.Kernel.Domain.DomainEvents.Handler;
using Sistran.Kernel.Domain.Notification.Event;

namespace Sistran.API.Controlers.Base
{
    public class BaseController: ApiController
    {
        private readonly IHandler<DomainNotification> _notifications;
        protected HttpResponseMessage _response;

        public BaseController()
        {
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            _response = new HttpResponseMessage();
        }

        protected Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            if (_notifications.HasNotifications())
                _response = Request.CreateResponse(HttpStatusCode.BadRequest,
                    new { errors = _notifications.Notify() });
            else
                _response = Request.CreateResponse(code, result);

            return Task.FromResult(_response);
        }

        protected Task<HttpResponseMessage> CreateErrorResponse(HttpStatusCode code, string message)
        {
            if (_notifications.HasNotifications())
                _response = Request.CreateResponse(HttpStatusCode.BadRequest,
                    new { errors = _notifications.Notify() });
            else
                _response = Request.CreateResponse(code);

            return Task.FromResult(_response);
        }

        protected override void Dispose(bool disposing)
        {
            _notifications.Dispose();
        }
    }
}