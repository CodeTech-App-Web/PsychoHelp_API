using Microsoft.EntityFrameworkCore;

namespace PsychoHelp_API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
        {
            // Apply Naming Convention for Each Entity
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
                
                //Apply Naming Convention for Each Property
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                
                //Apply Naming Convention for Each Key
                foreach (var key in entity.GetKeys()) 
                    key.SetName(key.GetName().ToSnakeCase());
                
                //Apply Naming Convention for Each ForeingKey
                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                
                //Apply Naming Convention for Indexes
                foreach (var index in entity.GetIndexes()) 
                    index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
                
            }
        } 
    }
}