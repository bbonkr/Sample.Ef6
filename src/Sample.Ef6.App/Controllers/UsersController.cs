using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Sample.Ef6.Data;
using Sample.Ef6.Entities;

namespace Sample.Ef6.App.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    public UsersController(ApplicationDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK, "application/json")]
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await db.Users.Include(x => x.Address).AsNoTracking().ToListAsync();
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var user = await db.Users.Include(x => x.Address)
            .Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK, "application/json")]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        db.Users.Add(user);

        await db.SaveChangesAsync();

        return StatusCode(StatusCodes.Status201Created, user);
    }

    [HttpPut]
    [ProducesResponseType(typeof(User), StatusCodes.Status202Accepted, "application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromBody] User user)
    {
        var userToUpdate = await db.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync();

        if (userToUpdate == null)
        {
            return NotFound();
        }

        db.Update(user);

        await db.SaveChangesAsync();

        return Accepted(user);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id)
    {
        var user = await db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        
        if(user == null)
        {
            return NotFound();
        }

        db.Remove(user);

        await db.SaveChangesAsync();

        return Accepted();
    }

    private ApplicationDbContext db;
}