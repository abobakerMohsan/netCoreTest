using Products.Api.GraphQL.Queries;
using GraphQL.Types;
//using GraphQL.Utilities;





namespace Products.Api.GraphQL.Schemas {
    public class AppSchema : Schema {
        public AppSchema(IServiceProvider provider) : base(provider) {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }

        //public NotesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        //{
        //    Query = serviceProvider.GetRequiredService<NotesQuery>();
        //}
    }
}
