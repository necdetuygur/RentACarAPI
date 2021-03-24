using RentACar.Core.Models;
using RentACar.Core.Repositories;
using RentACar.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services
{
    public class FirmaDapperService : DapperService<Firma>
    {
        private readonly IDapperRepository<Firma> _dapperRepository;
        public FirmaDapperService(IDapperUnitOfWork uow, IDapperRepository<Firma> dapperRepository) : base(uow, dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<IEnumerable<Firma>> GetAllAsync()
        {
            string sql = "SELECT * FROM Firma";
            var result = await _dapperRepository.QueryAsync(sql);
            return result.ToList();
        }
    }
}
