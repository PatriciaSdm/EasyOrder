using EasyOrder.Business.Enums;
using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Interfaces.Services;
using EasyOrder.Business.Models;
using EasyOrder.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Services
{
    public class OrderService : Service, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository,
                            INotifier notifier) : base(notifier)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Get(Guid id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> GetWithItens(Guid id)
        {
            var teste = await _orderRepository.GetWithItens(id);
            return await _orderRepository.GetWithItens(id);
        }

        public async Task<IEnumerable<Order>> GetWithItens()
        {
            var teste = await _orderRepository.GetWithItens();
            return await _orderRepository.GetWithItens();
        }

        public async Task<bool> Include(Order order)
        {
            if (!ExecutarValidacao(new OrderValidation(), order)) return false;

            //TODO: Gerar numero ordem
            await _orderRepository.Include(order);
            return true;
        }

        public async Task<bool> Update(Order order)
        {
            if (!ExecutarValidacao(new OrderValidation(), order)) return false;

            var model = await _orderRepository.GetWithItens(order.Id);

            model.Name = order.Name;
            model.Table = order.Table;
            model.Status = order.Status;
            model.Discount = order.Discount;
            model.Subtotal = order.Subtotal;
            model.Total = order.Total;
            UpdateItemsList(order, model);

            await _orderRepository.Update(model);
            return true;
        }

        private static void UpdateItemsList(Order order, Order model)
        {
            //Itens pra atualizar
            model.Items.ForEach(x =>
            {
                var item = order.Items.FirstOrDefault(y => y.Id == x.Id);
                if (item != null)
                {
                    x.Quantity = item.Quantity;
                    x.Observation = item.Observation;
                    x.Status = item.Status;
                    UpdateExtrasList(item.ItemExtras, x.ItemExtras);
                }
            });

            //Itens removidos do Front
            var teste = model.Items.RemoveAll(x => !order.Items.Select(y => y.Id).Contains(x.Id));

            //Itens novos
            model.Items.AddRange(order.Items.Where(x => !model.Items.Select(y => y.Id).Contains(x.Id)));
        }

        private static void UpdateExtrasList(List<ItemExtra> orderItemExtras, List<ItemExtra> modelItemExtras)
        {
            //Itens removidos do Front
            modelItemExtras.RemoveAll(x => !orderItemExtras.Select(y => y.IdExtra).Contains(x.IdExtra));

            //Itens novos
            modelItemExtras.AddRange(orderItemExtras.Where(x => !modelItemExtras.Select(y => y.IdExtra).Contains(x.IdExtra)));
        }

        public async Task<bool> Close(Order order)
        {
            order.Status = StatusOrder.Closed;
            await _orderRepository.Update(order);
            return true;
        }

        public void Dispose()
        {
            _orderRepository?.Dispose();
        }
    }
}
