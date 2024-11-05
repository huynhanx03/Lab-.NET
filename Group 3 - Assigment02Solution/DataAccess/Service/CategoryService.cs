using AutoMapper;
using BusinessObject;
using DataAccess.Repository;


namespace DataAccess.Service
{
    public class CategoryService
    {
        private readonly IRepositoryCategory _categoryService;
        private IMapper _mapper;
        public CategoryService
            (
            IRepositoryCategory categoryService,
            IMapper mapper
            )
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetPagingList()
        {
            try
            {
                var category = await _categoryService.GetList();
                return _mapper.Map<List<CategoryDto>>(category);
            }
            catch ( Exception ex )
            {
                throw;
            }
            
        }
    }
}
