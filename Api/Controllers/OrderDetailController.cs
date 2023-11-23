using Api.Controllers;
using Api.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class OrderDetailController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public OrderDetailController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrderDetailDto>>> Get()
    {
        var entidad = await unitofwork.OrderDetails.GetAllAsync();
        return mapper.Map<List<OrderDetailDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<OrderDetailDto>> Get(string id)
    {
        var entidad = await unitofwork.OrderDetails.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<OrderDetailDto>(entidad);
    }


    // //CONSULTA 19
    // [HttpGet("GetTypeProCustomer")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<object>> GetTypeProCustomer()
    // {
    //     var entidad = await unitofwork.OrderDetails.GetTypeProCustomer();
    //     var dto = mapper.Map<IEnumerable<object>>(entidad);
    //     return Ok(dto);
    // }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrderDetail>> Post(OrderDetailDto entidadDto)
    {
        var entidad = this.mapper.Map<OrderDetail>(entidadDto);
        this.unitofwork.OrderDetails.Add(entidad);
        await unitofwork.SaveAsync();
        if (entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new { id = entidadDto.Id }, entidadDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<OrderDetailDto>> Put(int id, [FromBody] OrderDetailDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<OrderDetail>(entidadDto);
        unitofwork.OrderDetails.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var entidad = await unitofwork.OrderDetails.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.OrderDetails.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
