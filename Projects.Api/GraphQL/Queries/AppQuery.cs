using Products.Api.GraphQL.Types;
using GraphQL.Types;
using MediatR;
using GraphQL;
using System;
using Products.Application.Features.Products.Queries.GetProductsList;
using Products.Domain.Entites;
using System;
using Products.Application.Features.Branches.Queries.GetBranchesList;
using Projects.Api.GraphQL.Types;
using Products.Application.Features.Employes.Queries.GetEmployesList;
using Products.Application.Features.Sizes.Queries.GetSizesList;

namespace Products.Api.GraphQL.Queries {
    public class AppQuery : ObjectGraphType {


        //public AppQuery()
        //{
        //    Field<ListGraphType<ProductType>>("notes", resolve: _context => new List<Product> {
        //  new Product { Id = Guid.NewGuid(), Description = "Hello World!" },
        //  new Product { Id = Guid.NewGuid(), Description = "Hello World! How are you?" }
        //});
        //}

        public AppQuery(ISender mediator)
        {
            FieldAsync<ListGraphType<BrancheType>>(
                "Branches",
                resolve: async context => await mediator.Send(new GetBranchesListQuery()),
                description: "Get all Branche"
           );
            FieldAsync<ListGraphType<EmployeType>>(
             "Employes",
             resolve: async context => await mediator.Send(new GetEmployesListQuery()),
             description: "Get all Employe"
        );

            FieldAsync<ListGraphType<SizeType>>(
             "Sizes",
             resolve: async context => await mediator.Send(new GetSizesListQuery()),
             description: "Get all Size Type"
        );
            FieldAsync<ListGraphType<ProductType>>(
           "products",
           resolve: async context => await mediator.Send(new GetProductsListQuery()),
           description: "Get all Product with sizes"
      );


            //FieldAsync<SizeType>(
            //    "sizes",
            //    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "sizeId" }),
            //    resolve: async context => {
            //        try {
            //            int id = context.GetArgument<int>("sizeId");
            //            return await mediator.Send(new GetSessionQuery(id));
            //        } catch (Exception e) {
            //            throw new ExecutionError(e.Message);
            //        }
            //    });



        }
        }
}
