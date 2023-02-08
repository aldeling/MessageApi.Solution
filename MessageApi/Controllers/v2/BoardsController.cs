using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageApi.Models;

namespace MessageApi.Controllers.v2
{
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiVersion("2.0")]
  public class BoardsController: ControllerBase
  {
    private readonly MessageApiContext _db;

    public BoardsController(MessageApiContext db)
    {
      _db = db;
    }

    // GET api/animals
    [HttpGet]
    public async Task<List<Board>> Get(string userName, string userMessage)
    {
      IQueryable<Board> query = _db.Boards.AsQueryable();
      
      if (userName != null)
      {
        query = query.Where(entry => entry.UserName == userName);
      }

      if (userMessage != null)
      {
        query = query.Where(entry => entry.UserMessage == userMessage);
      }

      return await query.ToListAsync();
    }

    // GET: api/Boards/#
    [HttpGet("{id}")]
    public async Task<ActionResult<Board>> GetBoard(int id)
    {
      Board board = await _db.Boards.FindAsync(id);

      if (board == null)
      {

        return NotFound();
      }
      return board;
    }

    //POST: api/Boards
    [HttpPost]
    public async Task<ActionResult<Board>> Post([FromBody] Board board)
    {
      _db.Boards.Add(board);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetBoard), new { id = board.BoardId }, board);
    }

    //PUT: api/Boards/#
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Board board)
    {
      if (id != board.BoardId)
      {
        return BadRequest();
      }

      _db.Boards.Update(board);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BoardExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    private bool BoardExists(int id)
    {
      return _db.Boards.Any(e => e.BoardId == id);
    }

    // DELETE: api/boards/#
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      Board board = await _db.Boards.FindAsync(id);
      if (board == null)
      {
        return NotFound();
      }
      _db.Boards.Remove(board);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}