using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using app.catalog_browsing;
using app.request_handling;
using developwithpassion.specifications.extensions;

namespace app.stubs
{
  public class StubHandlers : IEnumerable<IHandleOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IHandleOneRequest> GetEnumerator()
    {
      yield return new Handler(x => true, create_feature<ViewTheMainDepartmentsInTheStore>());
      yield return new Handler(x => true, create_feature<ViewDeparmentsInADepartment>());
      yield return new Handler(x => true, create_feature<ViewProductsInADepartment>());
    }

    public IRunAFeature create_feature<Feature>() where Feature : IRunAFeature, new()
    {
      IRunAFeature feature = new Feature();

      return feature;
    }
  }
}