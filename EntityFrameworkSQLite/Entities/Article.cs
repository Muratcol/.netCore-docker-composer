
namespace EntityFrameworkSQLite.Entities
{
  /// <summary>
  /// Class Article
  /// </summary>
  public class Article
  {
    /// <summary>
    /// Gets or sets the order identifier.
    /// </summary>
    /// <value>The order identifier.</value>
    public int ArticleID { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Body { get; set; }

    /// <summary>
    /// Gets or sets the title
    /// </summary>
    /// <value>The product ids.</value>
    public string Title {get; set;}
  }
}