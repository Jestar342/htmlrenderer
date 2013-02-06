using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace HtmlRenderer.Helpers.Mvc
{
    public static class ViewContextExtendsions
    {
         public static void RenderValidationFor<T>(this IHtmlBuilder htmlBuilder, ViewContext viewContext, Expression<Func<T>> expression)
         {
             var modelName = ExpressionHelper.GetExpressionText(expression);
             htmlBuilder.Heading(1).With(builder => builder.Text(modelName));

             var viewData = viewContext.ViewData;
             if (viewData.ModelState.IsValidField(modelName)) return;

             htmlBuilder.UnorderedList.With(builder => viewData.ModelState[modelName].Errors
                                                           .ToList().ForEach(error => builder.ListItem
                                                                                          .Class("field-validation-error")
                                                                                          .With(builder1 => builder1.Text(error.ErrorMessage))));
         }
    }
}