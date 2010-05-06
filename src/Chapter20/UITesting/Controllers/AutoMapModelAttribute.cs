using System;
using System.Web.Mvc;
using AutoMapper;

namespace UITesting.Controllers
{
    public class AutoMapResult<TModel> : ActionResult
    {
        public AutoMapResult(ActionResult inner)
        {
            Inner = inner;
        }

        public ActionResult Inner { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            object source = context.Controller.ViewData.Model;
            // blarg
            object map = Mapper.Map(source, source.GetType(), typeof(TModel));
            context.Controller.ViewData.Model = map;

            Inner.ExecuteResult(context);
        }
    }
}