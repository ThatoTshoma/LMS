using LMS_Demo.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LMS_Demo.Repositories
{
    public interface IReportReposit
    {

        Task<IEnumerable<Result>> GetResult();
        
    }
}
