using CivilIDWeb.DB.Entities;

namespace CivilIDWeb.DB.Repository
{
    public interface IPACIRequestLogRepository
    {
        IEnumerable<PacirequestLog> GetAll(int pageNo, int pageSize);
        //Employee GetById(int EmployeeID);
        //void Insert(Employee employee);
        //void Update(Employee employee);
        //void Delete(int EmployeeID);
        //void Save();
    }
}