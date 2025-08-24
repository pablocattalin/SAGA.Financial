using Backend.Domain.Contract.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Persistence.Database
{
    public class StronglyTypedIdValueConverter<T> : ValueConverter<T, Guid> where T : Identity, new()
    {
        public StronglyTypedIdValueConverter()
            : base(
            id => id.Id,
                value => Identity.ParseFromGuid<T>(value),
                null)
        { }
    }
}
