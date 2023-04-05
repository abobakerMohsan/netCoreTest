
using GraphQL.Types;
using MediatR;
using Products.Api.GraphQL.Types;
using Products.Domain.Entites;

namespace Products.Api.GraphQL.Types {
    public class ProductType : ObjectGraphType<Product> {
        public ProductType(ISender mediator) {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Id property from the Product object.");
            Field(f => f.Name, type: typeof(StringGraphType)).Description("Product name.");
            Field(f => f.Sizes, type: typeof(ListGraphType<SizeProductType>)).Description("Product sizes.");
        }
    }
}
