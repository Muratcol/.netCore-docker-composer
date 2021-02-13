using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkSQLite.DataAccessLayer;
using EntityFrameworkSQLite.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSQLite.Controllers
{
  /// <summary>
  /// Class OrdersController.
  /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
  /// </summary>
  /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
  [ApiController, Route("api/[controller]")]
  public class TestController : ControllerBase
  {
    /// <summary>
    /// The orders database context
    /// </summary>
    private readonly OrderDbContext _ordersDbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestController"/> class.
    /// </summary>
    /// <param name="ordersDbContext">The orders database context.</param>
    public TestController(OrderDbContext ordersDbContext)
    {
      this._ordersDbContext = ordersDbContext;
    }

    //GET: api/Tests
    /// <summary>
    /// A test get request
    /// </summary>
    /// <returns>Task&lt;ActionResult&lt;IEnumerable&lt;Order&gt;&gt;&gt;.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetTestResults()
    {
      return Ok(await _ordersDbContext.Orders.ToListAsync());
    }

    // GET: api/Tests/5
    /// <summary>
    /// Gets the order.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;ActionResult&lt;Order&gt;&gt;.</returns>
    [HttpGet("{id}")]
    public string MyFunc()
    {
      var test = "SONUNDA OROSPU COUGUG";
      return test;
    }

    // PUT: api/Tests/5
    /// <summary>
    /// Puts the order.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="order">The order.</param>
    /// <returns>Task&lt;IActionResult&gt;.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder(int id, Order order)
    {
      if (id != order.OrderId)
      {
        return BadRequest();
      }

      _ordersDbContext.Entry(order).State = EntityState.Modified;

      try
      {
        await _ordersDbContext.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!IsOrderExists(id))
        {
          return NotFound();
        }

        throw;
      }

      return NoContent();
    }

    // POST: api/Tests
    /// <summary>
    /// Posts the order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns>Task&lt;ActionResult&lt;Order&gt;&gt;.</returns>
    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
      _ordersDbContext.Orders.Add(order);
      await _ordersDbContext.SaveChangesAsync();

      return CreatedAtAction("GetTestResults", new { id = order.OrderId }, order);
    }

    // DELETE: api/Tests/5
    /// <summary>
    /// Deletes the order.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;ActionResult&lt;Order&gt;&gt;.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Order>> DeleteOrder(int id)
    {
      var order = await _ordersDbContext.Orders.FindAsync(id);
      if (order == null)
      {
        return NotFound();
      }

      _ordersDbContext.Orders.Remove(order);
      await _ordersDbContext.SaveChangesAsync();

      return Ok(order);
    }

    /// <summary>
    /// Determines whether [is order exists] [the specified identifier].
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns><c>true</c> if [is order exists] [the specified identifier]; otherwise, <c>false</c>.</returns>
    private bool IsOrderExists(int id)
    {
      return _ordersDbContext.Orders.Any(e => e.OrderId == id);
    }
  }
}