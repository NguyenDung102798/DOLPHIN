using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;
using DOLPHIN.Repository.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.Repository.UnitOfWorks
{
    public class OrderUnitOfWork : UnitOfWorkBase, IOrderUnitOfWork
    {
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;
        private IOrderDetailRepository orderDetailRepository;

        public OrderUnitOfWork(IDbContext context)
            : base(context)
        {
        }

        public IOrderRepository OrderRepository => throw new NotImplementedException();

        public IProductRepository ProductRepository => throw new NotImplementedException();

        public IOrderDetailRepository OrderDetailRepository => throw new NotImplementedException();
    }
}
