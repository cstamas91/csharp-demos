using Microsoft.AspNetCore.Mvc;
using ConcurrencyDbContext.WS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data;
using System;
using System.Threading;

namespace ConcurrencyDbContext.WS.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly QueryContext query;
        private readonly ModifyContext modify;

        public TestController(QueryContext query, ModifyContext modify)
        {
            this.query = query;
            this.modify = modify;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string term, CancellationToken ct = default)
        {
            try
            {
                using var tran = modify.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
                var asds = await modify.ASDs.ToListAsync(ct);
                asds[0].Content = asds[0].Content == "HELLO" ? asds[0].Content.ToLower() : asds[0].Content.ToUpper();
                asds[1].Content = asds[1].Content == "WORLD" ? asds[0].Content.ToLower() : asds[0].Content.ToUpper();
                await modify.SaveChangesAsync(ct);
                var result = await query
                    .TestTables
                    .FromSqlInterpolated($"select * from dbo.fnTestFunc({term})")
                    .ToListAsync(ct);
                tran.Commit();
                return Ok(new
                {
                    a = result,
                    b = asds
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
