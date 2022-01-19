using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Shopping.Domain.DTOs;
using Shopping.Domain.Entities;
using Shopping.Domain.View_Entities;

namespace Shopping.Infrastructure.Providers
{
    public class ODataEdmProvider
    {
        private ODataConventionModelBuilder EdmModelBuilder { get; set; }

        public ODataEdmProvider()
        {
            EdmModelBuilder = new ODataConventionModelBuilder();

            AddUserConfiguration();
            AddShoppingListConfiguration();
            AddShoppingListReportConfiguration();
        }
        public IEdmModel GetEdmModel()
        {
            return EdmModelBuilder.GetEdmModel();
        }

        private void AddUserConfiguration()
        {
            var configuration = EdmModelBuilder.EntitySet<UserDto>("User");
            var entityType = configuration.EntityType;

            entityType.HasKey(x => x.Id);

            entityType.Property(x => x.Name);
        }

        private void AddShoppingListConfiguration()
        {
            var configuration = EdmModelBuilder.EntitySet<ShoppingListDto>("ShoppingList");
            var entityType = configuration.EntityType;

            entityType.HasKey(x => x.Id);

            entityType.CollectionProperty(x => x.ShoppingItems);

            entityType.Property(x => x.UserId);
            entityType.Property(x => x.ShoppingListTotalValue);
        }
        private void AddShoppingListReportConfiguration()
        {
            var configuration = EdmModelBuilder.EntitySet<ShoppingListReport>("ShoppingListReport");
            var entityType = configuration.EntityType;

            entityType.HasKey(x => x.Id);

            entityType.Property(x => x.ShoppingListId);
            entityType.Property(x => x.UserId);
            entityType.Property(x => x.UserName);
            entityType.Property(x => x.ShoppingItemNames);
            entityType.Property(x => x.ShoppingListTotalValue);
        }
    }
}
