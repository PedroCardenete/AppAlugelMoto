using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Service;

public class SubscriberService
{
    private readonly ISubscriberRepository _subscriberRepository;

    public SubscriberService(ISubscriberRepository subscriberRepository)
    {
        _subscriberRepository = subscriberRepository;
    }

    public async Task<IEnumerable<Subscriber>> GetAllSubscribersAsync()
    {
        return await _subscriberRepository.GetAllAsync();
    }

    public async Task<Subscriber> GetSubscriberByIdAsync(int id)
    {
        return await _subscriberRepository.GetByIdAsync(id);
    }

    public async Task AddSubscriberAsync(Subscriber subscriber)
    {
        await _subscriberRepository.AddAsync(subscriber);
    }

    public async Task UpdateSubscriberAsync(Subscriber subscriber)
    {
        await _subscriberRepository.UpdateAsync(subscriber);
    }

    // public async Task DeleteSubscriberAsync(int id)
    // {
    //     var subscriber = await _subscriberRepository.GetByIdAsync(id);
    //     if (subscriber != null)
    //     {
    //         await _subscriberRepository.DeleteAsync(subscriber);
    //     }
    // }
}