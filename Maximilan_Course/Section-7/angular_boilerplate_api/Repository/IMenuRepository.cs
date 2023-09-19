using BoilerPlate.Request.Menu;
using BoilerPlate.Response.Menu;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Repository
{
    public interface IMenuRepository
    {
        public MenuResponse CreateMenu(MenuRequest menuRequest);

        public IEnumerable<MenuResponse> GetMenu();

        public void UpdateMenu (int id, [Required] MenuRequest menuRequest);

        public void DeleteMenu (int id);
    }
}