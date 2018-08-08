using NFine.Application.Config;
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain._03_Entity.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.Config.Controllers
{
    public class MaterialController : ControllerBase
    {
        private MaterialApp materialApp = new MaterialApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = materialApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(MaterialEntity materialEntity, string keyValue)
        {
            materialApp.SubmitForm(materialEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = materialApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
    }
}
