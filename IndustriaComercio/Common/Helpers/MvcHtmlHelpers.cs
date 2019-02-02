using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace IndustriaComercio.Common.Helpers
{
    public static class MvcHtmlHelpers
    {
        public static MvcHtmlString DescriptionFor<TModel, TValue>(
            this HtmlHelper<TModel> self,
            Expression<Func<TModel, TValue>> expression
            )
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var description = metadata.Description;

            return MvcHtmlString.Create(string.Format(@"{0}", description));
        }
    }
}