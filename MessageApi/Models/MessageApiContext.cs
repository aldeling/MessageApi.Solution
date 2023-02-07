using Microsoft.EntityFrameworkCore;

namespace MessageApi.Models
{
  public class MessageApiContext : DbContext
  {
    public DbSet<Board> Boards { get; set; }
    public MessageApiContext(DbContextOptions<MessageApiContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Board>()
        .HasData(
          new Board { BoardId = 1, UserName = "Tiger23", UserMessage = "Meow", Date = new DateTime(2023, 02, 06)},
          new Board { BoardId = 2, UserName = "Jon56", UserMessage="Am I holy?", Date = new DateTime(1000, 12, 25)},
          new Board { BoardId = 3, UserName = "FluffyPanda", UserMessage = "What's the secret ingredient?", Date = new DateTime(2008, 07, 04)}
        );
    }
  }
}