using NFine.Code;
using NFine.Domain._03_Entity.Config;
using NFine.Domain._04_IRepository.Config;
using NFine.Repository.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.Config
{
    public class MaterialApp
    {
        private IMaterialRepository service = new MaterialRepository();
        public List<MaterialEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<MaterialEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.Material_No.Contains(keyword));
                expression = expression.Or(t => t.Material_Name.Contains(keyword));
                expression = expression.Or(t => t.Material_Type.Contains(keyword));
            }
            //expression = expression.And(t => t.F_Account != "admin");
            return service.FindList(expression, pagination);
        }

        public void SubmitForm(MaterialEntity materialEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                materialEntity.Modify(keyValue);
                service.Update(materialEntity);
            }
            else
            {
                materialEntity.Create();
                service.Insert(materialEntity);
            }
        }

        public MaterialEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
    }
}
