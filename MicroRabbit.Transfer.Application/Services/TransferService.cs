using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IEventBus _eventBus;
        private readonly ITransferRepository _transferRepository;
        public TransferService(IEventBus eventBus,
            ITransferRepository transferRepository) 
        {
            _eventBus = eventBus;
            _transferRepository = transferRepository;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }

        public Task TransferAsync(decimal amount, int fromAccount, int toAccount)
        {
            return Task.CompletedTask;
        }
    }
}
