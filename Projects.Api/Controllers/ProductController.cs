using Products.Application.Features.Products.Commands.CreateProduct;
using Products.Application.Features.Products.Queries.GetProductDetail;
using Products.Application.Features.Products.Queries.GetProductsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Products.Api.Controllers
{
    [Route("api/product/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllProducts")]
        public async Task<ActionResult<List<GetProductsListViewModel>>> GetAllProducts()
        {
            var dtos = await _mediator.Send(new GetProductsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<GetProductDetailViewModel>> GetProductById(Guid id)
        {
            var getEventDetailQuery = new GetProductDetailQuery() { ProductId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            Guid id = await _mediator.Send(createProductCommand);
            return Ok(id);
        }

    

    }
}
