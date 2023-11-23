# Administración de la jardinería.

## Introducción
Este proyecto proporciona una API la cual podrás utilizar para la administracion y organizacion de la informacion de la empresa. Se cuenta con un sistema de autorizacion, restringiendo el acceso de información a determinados roles. En este caso solo aquel con el rol "Administrador" podrá regisrar, adregar, eliminar y demas para un usuario. 


## Endpoints Especificos ⌨️

❗ Recordar que en cada consulta encontramos dos versiones. La `1.0`, la cual responde correctamente la informacion requerida y la `1.1`, la cual nos responde con la informacion pero en esta ocasion implementando la paginación.

🕹 Para consultar la versión 1.0 de todos se ingresa únicamente el Endpoint; para consultar la versión 1.1 se deben seguir los siguientes pasos: 

En el Thunder Client se va al apartado de "Headers" y se escribes lo siguiente: `X-Version` con la version 1.1.

![image](https://github.com/Danilop109/Backend-Vet/assets/124645738/c42e2861-0386-422a-8146-9093c97319f7)

Para modificar la paginación vas al apartado de "Query" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/22683e46-037e-4f30-96b8-161df8622b40)

 ⚠️ - Recuerda tener un token e implementarlo en Auth.
 ![image](https://github.com/Danilop109/Backend-Vet/assets/124645738/43cb1ba6-9cf1-4999-a596-45ba5bd811dc)

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
    
    **Explicacion**: `En esta iniciamos con nuestra entidad`
    

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
    
    **Explicacion**: `En`


## Agradecimientos

¡Gracias por usar este proyecto! Si tienes alguna pregunta o sugerencia, no dudes en ponerte en contacto con la creadora.
Con cariño Daniela López.