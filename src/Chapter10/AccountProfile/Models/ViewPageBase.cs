using System.Web.Mvc;

namespace AccountProfile.Models
{
public class ViewPageBase<TModel> : ViewPage<TModel>
{
    public ParamBuilder Param { get { return new ParamBuilder(); } }
}
}