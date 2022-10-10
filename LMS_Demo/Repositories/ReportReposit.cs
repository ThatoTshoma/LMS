using LMS_Demo.Data;
using LMS_Demo.Models;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_Demo.Repositories
{
    public class ReportReposit : IReportReposit
    {
        private readonly ApplicationDBContext _db;

        public ReportReposit(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Result>> GetResult()
        {
            var relationshipsContext = _db.Results.Include(r => r.Module).Include(r => r.Mark);
            return await relationshipsContext.ToListAsync();
        }
    }
}
