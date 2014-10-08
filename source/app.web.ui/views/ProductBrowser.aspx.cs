using System.Collections.Generic;
using app.catalog_browsing;
using app.request_handling.aspnet;

namespace app.web.ui.views
{
    public partial class ProductBrowser : ViewFor<IEnumerable<ProductSummaryLine>>
    {
    }
}
