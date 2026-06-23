using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Products;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Products
{
    public interface IForceChoiceRepository : IGenericRepository<ForceChoice>
    {
        Task<IEnumerable<ForceChoice>> GetAllByOptionIndex(Guid clientId, int optionIndex);
    }
}
