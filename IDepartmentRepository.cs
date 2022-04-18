using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
    }
}
