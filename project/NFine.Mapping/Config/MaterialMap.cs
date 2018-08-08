using NFine.Domain._03_Entity.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.Config
{
    public class MaterialMap : EntityTypeConfiguration<MaterialEntity>
    {
        public MaterialMap()
        {
            this.ToTable("Conf_Material");
            this.HasKey(t => t.F_Id);
        }
    }
}
