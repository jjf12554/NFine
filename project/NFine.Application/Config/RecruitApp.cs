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
    public class RecruitApp
    {
        private IRecruitRepository service = new RecruitRepository();
        public void SubmitForm(RecruitEntity recruitEntity, string keyValue="")
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                recruitEntity.Modify(keyValue);
                service.Update(recruitEntity);
            }
            else
            {
                recruitEntity.Create();
                service.Insert(recruitEntity);
            }
        }

        public bool IsRecruitExit(string url)
        {
            RecruitEntity recruitEntity2 = service.GetRecruit(url);
            if (recruitEntity2 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SubmitForm(List<RecruitEntity> recruitEntitys)
        {
            foreach (var recruitEntity in recruitEntitys)
            {
                recruitEntity.Create();
            }
            service.Insert(recruitEntitys);
        }
    }
}
