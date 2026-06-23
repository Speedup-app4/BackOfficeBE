using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Table;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.Table
{
    public class SectionService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<Section>> GetAll(Guid clientId)
        {
            return await _uow.Section.GetAllAsync(true, clientId);
        }

        public async Task<Section> Create(Guid clientId, Section section)
        {
            try
            {
                _uow.BeginTransaction();
                var SECNUM = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_SECTIONS,
                    clientId
                );
                section.SECNUM = SECNUM;
                section.ClientId = clientId;

                var createdSection = await _uow.Section.AddAsync(section);
                _uow.Commit();
                return createdSection;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<Section> Update(Guid clientId, SectionUpdate section)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedSection = await _uow.Section.UpdatePartialAsync(
                    section,
                    section.SECNUM,
                    clientId
                );
                _uow.Commit();
                return updatedSection;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
