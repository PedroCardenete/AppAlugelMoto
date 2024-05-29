using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Service;

public class OrderService
 {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, ILocationRepository locationRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task AddOrderAsync(Order order)
        {
            order.CreatedDate = DateTime.UtcNow;
            await _orderRepository.AddAsync(order);
            NotifyDeliveryDrivers(order);
        }

        public async Task AcceptOrderAsync(int id, int userId)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new InvalidOperationException("Pedido não encontrado.");
            }

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("Entregador não encontrado.");
            }

            // if (!order.NotifiedUsers.Contains(user))
            // {
            //     throw new InvalidOperationException("Entregador não notificado para este pedido.");
            // }

            order.Situation = "aceito";
            // order.UserId = userId;

            await _orderRepository.UpdateAsync(order);
        }

        public async Task CompleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new InvalidOperationException("Pedido não encontrado.");
            }

            order.Situation = "entregue";
            await _orderRepository.UpdateAsync(order);
        }

        private void NotifyDeliveryDrivers(Order order)
        {
            // Implementar lógica para notificar entregadores
            // ...
        }
    }