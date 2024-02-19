using GroupTogether.Data;
using GroupTogether.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupTogether.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context) 
        {
            _context = context;
        }

        //新增以下兩個ednpoint，用以處理HTTP GET的請求

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() // 表示這個異步方法最終將返回一個動作結果，這個動作結果包含了一個 AppUser 的可枚舉集合。
        {
            return await _context.Users.ToListAsync();//_context.Users.ToListAsync() 是 Entity Framework Core 的 LINQ 方法，用於異步地從數據庫中檢索 Users 表的所有記錄並將它們轉換成一個 List<AppUser>。這個列表最終會被包裹在 ActionResult 中返回。
        }
        //通過使用 await 關鍵字，這個方法會等待 ToListAsync() 方法的異步操作完成，這個操作會檢索數據庫中的所有用戶並將它們轉換為一個列表。
        //api/users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
