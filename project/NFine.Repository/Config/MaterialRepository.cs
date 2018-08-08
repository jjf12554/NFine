using NFine.Data;
using NFine.Domain._03_Entity.Config;
using NFine.Domain._04_IRepository.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.Config
{
    public class MaterialRepository : RepositoryBase<MaterialEntity>, IMaterialRepository
    {
    }
}
