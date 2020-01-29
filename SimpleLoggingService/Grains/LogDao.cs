using System.Threading.Tasks;
using SimpleLoggingInterfaces.Interfaces;
using SimpleLoggingService.Interfaces;

namespace SimpleLoggingService.Grains
{
    public class LogDao : Orleans.Grain, ILogDao
    {
        public Task<bool> InsertApplicationError(IApplicationEntity applicationEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertApplicationLog(IApplicationEntity applicationEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertMessageQueueError(IMessageQueueEntity messageQueueEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertMessageQueueLog(IMessageQueueEntity messageQueueEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertRelationalDatabaseError(IRelationalDatabaseEntity relationalDatabaseEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertRelationalDatabaseLog(IRelationalDatabaseEntity relationalDatabaseEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertTransactionError(ITransactionEntity transactionEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertTransactionLog(ITransactionEntity transactionEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}