﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.Providers
{
    public class ODataEdmProvider
    {
        private ODataConventionModelBuilder EdmModelBuilder { get; set; }

        public ODataEdmProvider()
        {
            EdmModelBuilder = new ODataConventionModelBuilder();

            AddUserConfiguration();
        }
        public IEdmModel GetEdmModel()
        {
            return EdmModelBuilder.GetEdmModel();
        }

        private void AddUserConfiguration()
        {
            var configuration = EdmModelBuilder.EntitySet<User>("User");
            var entityType = configuration.EntityType;

            entityType.HasKey(x => x.Id);
            entityType.Property(x => x.Name);
        }
    }
}