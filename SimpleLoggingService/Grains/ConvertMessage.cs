using Newtonsoft.Json;
using SimpleLoggingInterfaces.Interfaces;
using SimpleLoggingService.Grains;
using SimpleLoggingService.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;
using static SimpleLoggingInterfaces.Enums.EnumCollection;

namespace Grains
{
    public class ConvertMessage : Orleans.Grain, IConvertMessage
    {
        async Task<bool> IConvertMessage.ConvertMessage(byte[] message)
        {
             IPayload payload = (IPayload)TryParse<PayloadEntity>(Encoding.UTF8.GetString(message));
             return await LogRouting(payload);
        }

        private async Task<bool> LogRouting(IPayload payload)
        {
            bool isSuccess = false;

            try
            {
                switch (payload.LogType)
                {
                    case LogType.Application:
                        IApplicationEntity applicationEntity = (IApplicationEntity)payload.Payload;
                        break;
                    case LogType.MessageQueue:
                        IMessageQueueEntity messageQueueEntity = (IMessageQueueEntity)payload.Payload;
                        break;
                    case LogType.RelationalDatabase:
                        IRelationalDatabaseEntity relationalDatabaseEntity = (IRelationalDatabaseEntity)payload.Payload;
                        break;
                    case LogType.Transaction:
                        ITransactionEntity transactionEntity = (ITransactionEntity)payload.Payload;
                        if (transactionEntity.TrasactionType == TransactionType.External)
                        { }
                        else
                        { }
                        break;
                }

                isSuccess = true;
                return isSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return isSuccess;
            }

        }

        private static T TryParse<T>(string descryptedMessage) where T : new()
        {
            try
            {
                // Validate missing fields of object
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Error;

                return JsonConvert.DeserializeObject<T>(descryptedMessage);
            }
            catch (Exception)
            {
               return default(T);
            }
        }
    }
}