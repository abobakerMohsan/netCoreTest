using GraphQL.Types;
using MediatR;
using Products.Api.GraphQL.Types;
using Products.Domain.Entites;


namespace Projects.Api.GraphQL.Types
{
        public class EmployeType : ObjectGraphType<Employe>
        {
            public EmployeType(ISender mediator)
            {
               
                Field(f => f.Id, type: typeof(IdGraphType)).Description("Id Employe.");
                Field(f => f.BranchesId, type: typeof(IdGraphType)).Description("BranchesId.");
                Field(f => f.UserId, type: typeof(IntGraphType)).Description("User Id.");
                Field(f => f.FullName, type: typeof(StringGraphType)).Description("Full Name");
                Field(f => f.Gender, type: typeof(IntGraphType)).Description("Gender.");
                Field(f => f.Address, type: typeof(StringGraphType)).Description("Address");
                Field(f => f.BirthDate, type: typeof(StringGraphType)).Description("BirthDate");
            
                Field(f => f.Address, type: typeof(StringGraphType)).Description("Address");
                Field(f => f.Branche, type: typeof(StringGraphType)).Description("Branche");



        }
    }

    }
