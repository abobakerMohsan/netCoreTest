using GraphQL.Types;
using MediatR;
using Products.Api.GraphQL.Types;
using Products.Domain.Entites;


namespace Projects.Api.GraphQL.Types
{
 
    public class BrancheType : ObjectGraphType<Branche>
    {
        public BrancheType(ISender mediator)
        {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Id Branche.");
            Field(f => f.Name, type: typeof(StringGraphType)).Description("Branche name.");
  
        }
    }


}

