using BoilerPlate.Repository;
using BoilerPlate.Request.Menu;
using BoilerPlate.Response.Menu;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {
        private readonly IMenuRepository menuRepository;

        public MenuController(IMenuRepository _menuRepository)
        {
            menuRepository = _menuRepository;
        }

        /// <summary>
        /// Create Menu
        /// </summary>
        /// <param name="menuRequest">Represents the object of Menu Request Class</param>
        /// <returns>Returns Response of Create Menu</returns>
        [HttpPost]
        public IActionResult CreateMenu(MenuRequest menuRequest)
        {
            var menu = menuRepository.CreateMenu(menuRequest);
            return Ok(menu);
        }

        /// <summary>
        /// Get Menu List
        /// </summary>
        /// <returns>Returns Response of getting the Menu</returns>
        [HttpGet]
        public IActionResult GetMenu()
        {
            var menus = menuRepository.GetMenu();
            return Ok(menus);
        }

        /// <summary>
        /// Update Menu
        /// </summary>
        /// <param name="Id">Represents the Id of Menu to be Updated</param>
        /// <param name="menuRequest">Represents the object of Menu Request Class</param>
        /// <returns>Returns the Updated Menu</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateMenu(int Id, [Required]MenuRequest menuRequest)
        {
            return Ok();
        }

        /// <summary>
        /// Delete Menu
        /// </summary>
        /// <param name="Id">Represents the Id of Menu to be Deleted</param>
        /// <returns>Returns the Deleted menu</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(int Id) 
        { 
            menuRepository.DeleteMenu(Id);
            return Ok(new DeleteMenuResponse()
            {
                Message = "Menu Deleted Successfully"
            });
        }
    }
}