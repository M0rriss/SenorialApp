using AutoMapper;
using DBSenorialModels.Senorial;
using IBusiness.Schema_Usuarios.Roles;
using IRepository.Schema_Usuarios.Roles;
using Repository.Schema_Usuarios.Roles;
using RequestResponseModels.Request.Schema_Generico.Filtro;
using RequestResponseModels.Request.Schema_Usuarios.Roles;
using RequestResponseModels.Response.Schema_Generico.Filtro;
using RequestResponseModels.Response.Schema_Usuarios.Roles;

namespace Business.Schema_Usuarios.Roles
{
    public class RolesBusiness : IRolesBusiness
    {
        #region Dependency Injecction
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;
        public RolesBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _rolesRepository = new RolesRepository();
        }
        #endregion
        #region CRUD
        public async Task<List<RolesResponse>> GetAll()
        {
            List<Role> roles = await _rolesRepository.GetAll();
            var response = _mapper.Map<List<RolesResponse>>(roles);
            return response;
        }
        public async Task<RolesResponse> GetById(int id)
        {
            Role roles = await _rolesRepository.GetById(id);
            var response = _mapper.Map<RolesResponse>(roles);
            return response;
        }

        public async Task<RolesResponse> Create(RolesRequest entity)
        {
            Role roles = _mapper.Map<Role>(entity);
            roles = await _rolesRepository.Create(roles);
            var response = _mapper.Map<RolesResponse>(roles);
            return response;
        }

        public async Task<List<RolesResponse>> CreateMultiple(List<RolesRequest> list)
        {
            var roles = _mapper.Map<List<Role>>(list);
            roles = await _rolesRepository.CreateMultiple(roles);
            var response = _mapper.Map<List<RolesResponse>>(roles);
            return response;
        }

        public async Task<RolesResponse> Update(RolesRequest entity)
        {
            var roles = _mapper.Map<Role>(entity);
            roles = await _rolesRepository.Update(roles);
            var response = _mapper.Map<RolesResponse>(roles);
            return response; ;
        }

        public async Task<List<RolesResponse>> UpdateMultiple(List<RolesRequest> list)
        {
            var roles = _mapper.Map<List<Role>>(list);
            roles = await _rolesRepository.UpdateMultiple(roles);
            var response = _mapper.Map<List<RolesResponse>>(roles);
            return response;
        }
        public async Task<int> Delete(int id)
        {
            int result = await _rolesRepository.Delete(id);
            return result;
        }

        public async Task<List<RolesRequest>> DeleteMultiple(List<RolesRequest> list)
        {
            var roles = _mapper.Map<List<Role>>(list);
            var deletedCount = await _rolesRepository.DeleteMultiple(roles);
            return list;

        }

        public async Task<GenericFilterResponse<RolesResponse>> GetByFilterAsync(GenericFilterRequest request)
        {
            var filtro = await _rolesRepository.GetByFilterAsync(request);
            var result = _mapper.Map<GenericFilterResponse<RolesResponse>>(filtro);
            return result;
        }

        public void Dispose()
        {
            _rolesRepository.Dispose();
        }

        #endregion
    }
}
