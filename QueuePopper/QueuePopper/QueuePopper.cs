using QueuePopper.Interfaces;
using System.Threading.Tasks;

namespace QueuePopper
{
    public class QueuePopper : IQueuePopper
    {
        private IDao _dao;

        public QueuePopper(IDao dao)
        {
            _dao = dao;
        }

        public async Task<object> GetMessage()
        {
            return await _dao.GetMessage();
        }
    }
}