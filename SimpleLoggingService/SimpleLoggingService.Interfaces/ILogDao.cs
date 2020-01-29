using SimpleLoggingInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLoggingService.Interfaces
{
    public interface ILogDao : Orleans.IGrainWithGuidKey
    {
        /// <summary>
        /// Logging Messages
        /// </summary>
        /// <param name="applicationEntity"></param>
        /// <returns></returns>
        Task<bool> InsertApplicationLog(IApplicationEntity applicationEntity);

        Task<bool> InsertMessageQueueLog(IMessageQueueEntity messageQueueEntity);

        Task<bool> InsertTransactionLog(ITransactionEntity transactionEntity);

        Task<bool> InsertRelationalDatabaseLog(IRelationalDatabaseEntity relationalDatabaseEntity);

        /// <summary>
        /// Logging Errors
        /// </summary>
        /// <param name="applicationEntity"></param>
        /// <returns></returns>
        Task<bool> InsertApplicationError(IApplicationEntity applicationEntity);

        Task<bool> InsertMessageQueueError(IMessageQueueEntity messageQueueEntity);

        Task<bool> InsertTransactionError(ITransactionEntity transactionEntity);

        Task<bool> InsertRelationalDatabaseError(IRelationalDatabaseEntity relationalDatabaseEntity);
    }
}