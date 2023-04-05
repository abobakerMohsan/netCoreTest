
using GraphQL.Types;
using MediatR;
using Products.Api.GraphQL.Types;
using Products.Domain.Entites;
using Products.Domain.Entities;

namespace Products.Api.GraphQL.Types
{
    public class SizeType : ObjectGraphType<Size>
    {
        public SizeType(ISender mediator)
        {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("ID.");
            Field(f => f.Name, type: typeof(StringGraphType)).Description("Name.");
            Field(f => f.Description, type: typeof(StringGraphType)).Description("Description");
       
        }
    }
}