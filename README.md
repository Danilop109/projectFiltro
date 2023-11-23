# Administración de la jardinería.

## Introducción
Este proyecto proporciona una API la cual podrás utilizar para la administracion y organizacion de la informacion de la empresa. Se cuenta con un sistema de autorizacion, restringiendo el acceso de información a determinados roles. En este caso solo aquel con el rol "Administrador" podrá regisrar, adregar, eliminar y demas para un usuario. 


## Endpoints Especificos ⌨️

## 1. Devuelve un listado con el código de pedido, codigo de cliente, fecha esperada, y fecha de entrega de los pedidos que no han sido entregados a tiempo.

    **Endpoint**: `http://localhost:5093/api/Order/InfoCustomer`
    
    **Metodo**: `public async Task<IEnumerable<object>> InfoCustomer()
        {
            var objeto = await
            (
                from p in _context.Orders
                join c in _context.Customers on p.IdCustomerCodeFk equals c.Id
                where p.ExpectedDeliveryDate < p.ActualDeliveryDate
                select new
                {
                    OrderCode = p.Id,
                    IdCustomer = p.IdCustomerCodeFk,
                    ExpectDate = p.ExpectedDeliveryDate,
                    ActualDate = p.ActualDeliveryDate
                }
            ).Distinct().ToListAsync();

            return objeto;
        }`

    **Explicacion**: `En esta consulta podemos iniciamos conectando las dos entidades que necesitamos, despues realizamos un filtro en el que pasaran aquellas fechas en las que el pedido llego despues y despues creamos un objeto con la informacion solicitada `


## 2. Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre de sus representantes de ventas con la ciudad de la oficinaa a la que pertenece el representante.:

    **Endpoint**: `http://localhost:5093/api/Payment/infoSalesRepreAndCustomer`

    **Método**: `public async Task<IEnumerable<object>> infoSalesRepreAndCustomer()
        {
            return await _context.Customers
            .Where(c => !c.Payments.Any())
            .Select(c => new{
                    CustomerName= c.CustomerName,
                    RepreName= c.SalesRepEmployeeCode.FirstName,
                    OfficeName= c.SalesRepEmployeeCode.Office.City}
            ).ToListAsync();
        }`
    
    **Explicacion**: `En esta buscamos los pagos que no tienen relacion alguna con un cliente y enviamos un informacion.`


## 3. Devuelve las oficinas donde no trabajan ninguno de los empleados que hayan sido los representantes de ventas de algún cliente que haya realizado la compra de algún producto de la gama Frutales.

    **Endpoint**: `http://localhost:5093/api/Office/GetOfficeAnyALotOfThings`

    **Método**: ` public async Task<IEnumerable<Office>> GetOfficeAnyALotOfThings()
        {
            var officesFru = await (
                from office in _context.Offices
                where !_context.Employees.Any(employee =>
                    _context.Customers.Any(customer =>
                        _context.Orders.Any(order =>
                            _context.OrderDetails.Any(orderDetail =>
                                orderDetail.IdOrderCodeFk == order.Id &&
                                order.IdCustomerCodeFk == customer.Id &&
                                customer.IdSalesRepEmployeeCodeFk == employee.Id &&
                                _context.Products.Any(product =>
                                    product.Id == orderDetail.IdProductCodeFk &&
                                    product.IdProductTypeFk == "Frutales"
                                )
                            )
                        )
                    )
                )
                select office
            ).ToListAsync();

            return officesFru;
        }`
    
    **Explicacion**: `En esta iniciamos con nuestra entidad principal la cual buscaremos los representates de venta que estan conectados con los empleados y a su vez aquellos clientes que no estan con alguna orden y en detalle orden buscamos y filtramos alaquellos que hicieron compra de la gama frutales.`
    

## 9.  Devuelve un listado con los datos de los empleados que no tienen clientes asociados y el nombre de su jefe asociado:

    **Endpoint**: `http://localhost:5093/api/Employee/GetNoCustEmployAndBoss`

    **Método**: `public async Task<IEnumerable<object>> GetNoCustEmployAndBoss()
        {
            var employes = await (
                from emp in _context.Employees
                join supervisor in _context.Employees on emp.IdSupervisorCodeFk equals supervisor.Id
                where !_context.Customers.Any(customer => customer.IdSalesRepEmployeeCodeFk == emp.Id)
                select new
                {
                    EmployeeName = emp.FirstName,
                    EmployeeLastName = emp.LastName1,
                    BossName = supervisor.FirstName
                }
            ).ToListAsync();

            return employes;
        }`
    
    **Explicacion**: `Inicamos con nuetsra entidad prinncipal y conectamos con clientes filtrando aquellos que no tienen el Id en esta misma entidad y despyes retornamos sus datos.
    `


## Agradecimientos

¡Gracias por usar este proyecto! Si tienes alguna pregunta o sugerencia, no dudes en ponerte en contacto con la creadora.
Con cariño Daniela López.