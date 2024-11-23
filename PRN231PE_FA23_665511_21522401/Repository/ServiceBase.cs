using AutoMapper;
using DataAccess.Models;

namespace Repository;
public class ServiceBase<T> : GenericRepository<T> where T : class
{
    public ServiceBase(SilverJewelry2023DbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
