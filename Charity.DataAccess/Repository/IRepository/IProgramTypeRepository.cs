using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charity.Models;

namespace Charity.DataAccess.Repository.IRepository
{
    public interface IProgramTypeRepository : IRepository<ProgramType>
    {
        void Update(ProgramType obj);

    }
}
