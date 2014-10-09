using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using developwithpassion.specifications.extensions;

namespace app.test_utilities
{
  public class ObjectFactory
  {
    public class expressions
    {
      public static ExpressionBuilder<T> to_target<T>()
      {
        return new ExpressionBuilder<T>();
      }

      public class ExpressionBuilder<T>
      {
        public ConstructorInfo ctor_detail(Expression<Func<T>> ctor)
        {
          return ctor.Body.downcast_to<NewExpression>().Constructor;
        }
      }
    }

    public static expressions.ExpressionBuilder<T> expressions_for<T>()
    {
      return expressions.to_target<T>();
    }

    public class web
    {
      public static HttpContext create_http_context()
      {
        return new HttpContext(create_request(), create_response());
      }

      static HttpRequest create_request()
      {
        return new HttpRequest("blah.aspx", "http://localhost/blah.aspx", String.Empty);
      }

      static HttpResponse create_response()
      {
        return new HttpResponse(new StringWriter());
      }
    }
  }
}