using AutoMapper;
using BoilerPlate.DbConnector;
using BoilerPlate.Models;
using BoilerPlate.Request.Menu;
using BoilerPlate.Response.Menu;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DatabaseExecutor databaseExecutor;

        private readonly IMapper mapper;

        public MenuRepository(DatabaseExecutor _databaseExecutor, IMapper _mapper)
        {
            databaseExecutor = _databaseExecutor;
            mapper = _mapper;
        }

        public MenuResponse CreateMenu(MenuRequest menuRequest)
        {
            var data = mapper.Map<MenuRequest, Menu> (menuRequest);
            var id = databaseExecutor.Create(data);
            data.Id = id;
            return mapper.Map<Menu, MenuResponse>(data);
        }

        public void DeleteMenu(int id)
        {
           databaseExecutor.Delete<Menu>(id);
        }

        public IEnumerable<MenuResponse> GetMenu()
        {
            var menus = databaseExecutor.GetAll<Menu>();
            var menuResponse = mapper.Map<List<Menu>, List<MenuResponse>>(menus.ToList());

            foreach (var menu in menuResponse)
            {
                var children = menuResponse.Where(x => x.ParentId == menu.Id).ToList();
                if (children.Count > 0)
                {
                    menu.ChildItems = children;
                }
            }

            menuResponse.RemoveAll(x => x.ParentId > 0);
            return menuResponse.OrderBy(x => x.Sequence);
        }

        public void UpdateMenu(int id, [Required] MenuRequest menuRequest)
        {
            throw new NotImplementedException();
        }
    }
}