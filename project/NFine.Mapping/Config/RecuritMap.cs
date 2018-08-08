using NFine.Domain._03_Entity.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.Config
{
    public class RecuritMap : EntityTypeConfiguration<RecruitEntity>
    {
        public RecuritMap()
        {
            this.ToTable("Conf_RECRUIT");
            this.HasKey(t => t.F_Id);
        }
    }
}
