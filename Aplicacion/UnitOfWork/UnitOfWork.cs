using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiJwtContext _context;
        private CustomerRepository _Customers;
        private EmployeeRepository _Employees;
        private OfficeRepository _Offices;
        private OrderRepository _Orders;
        private OrderDetailRepository _OrderDetails;
        private PaymentRepository _Payments;
        private ProductRepository _Products;
        private ProductTypeRepository _ProductTypes;
        public UnitOfWork(ApiJwtContext context)
        {
            _context = context;
        }

        public ICustomer Customers{
            get
            {
                if (_Customers == null)
                {
                    _Customers = new CustomerRepository(_context);
                }
                return _Customers;
            }
        }
        public IEmployee Employees {
            get
            {
                if (_Employees == null)
                {
                    _Employees = new EmployeeRepository(_context);
                }
                return _Employees;
            }
        }
        public IOffice Offices {
            get
            {
                if (_Offices == null)
                {
                    _Offices = new OfficeRepository(_context);
                }
                return _Offices;
            }
        }
        public IOrder Orders{
            get
            {
                if (_Orders == null)
                {
                    _Orders = new OrderRepository(_context);
                }
                return _Orders;
            }
        }
        public IOrderDetail OrderDetails {
            get
            {
                if (_OrderDetails == null)
                {
                    _OrderDetails = new OrderDetailRepository(_context);
                }
                return _OrderDetails;
            }
        }
        public IPayment Payments{
            get
            {
                if (_Payments == null)
                {
                    _Payments = new PaymentRepository(_context);
                }
                return _Payments;
            }
        }
        public IProduct Products {
            get
            {
                if (_Products == null)
                {
                    _Products = new ProductRepository(_context);
                }
                return _Products;
            }
        }
        public IProductType ProductTypes {
            get
            {
                if (_ProductTypes == null)
                {
                    _ProductTypes = new ProductTypeRepository(_context);
                }
                return _ProductTypes;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}