using CivilIDWeb.DB.APPContext;
using CivilIDWeb.DB.Entities;
using CivilIDWeb.Utility;

namespace CivilIDWeb.DB.Repository
{
    public class PACIRequestLogRepository : IPACIRequestLogRepository
    {
        private readonly PACIDBContext pACIDBContext;

        public PACIRequestLogRepository(PACIDBContext pACIDBContext)
        {
            this.pACIDBContext = pACIDBContext;
        }
        public IEnumerable<PacirequestLog> GetAll(int pageNo, int pageSize)
        {
            return (IEnumerable<PacirequestLog>)pACIDBContext.PacirequestLogs.GetPaged(pageNo, pageSize);

        }
    }
}
