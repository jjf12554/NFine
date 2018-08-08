using NFine.Data;
using NFine.Domain._03_Entity.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.Config
{
    public interface IRecruitRepository : IRepositoryBase<RecruitEntity>
    {
        RecruitEntity GetRecruit(string url);
    }
}
