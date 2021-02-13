using EntityFrameworkSQLite.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSQLite.DataAccessLayer
{
  /// <summary>
  /// Class ArticleDbContext.
  /// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
  /// </summary>
  /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
  public class ArticleDbContext : DbContext
  {
    /// <summary>
    /// Gets or sets the orders.
    /// </summary>
    /// <value>The orders.</value>
    public DbSet<Article> Articles { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderDbContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public ArticleDbContext(DbContextOptions<ArticleDbContext> options)
            : base(options)
    {
    }

    /// <summary>
    /// Override this method to further configure the model that was discovered by convention from the entity types
    /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
    /// and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
    /// define extension methods on this object that allow you to configure aspects of the model that are specific
    /// to a given database.</param>
    /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
    /// then this method will not be run.</remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed DB
      modelBuilder.Entity<Article>().HasData
          (
          new Article { ArticleID = 1, Title = "Dummy Article 1", Body = "Dummy Article Body 1" },
          new Article { ArticleID = 2, Title = "Dummy Article 2", Body = "Dummy Article Body 2" },
          new Article { ArticleID = 3, Title = "Dummy Article 3", Body = "Dummy Article Body 3" }
          );
    }
  }
}