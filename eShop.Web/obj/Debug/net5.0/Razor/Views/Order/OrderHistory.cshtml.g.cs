#pragma checksum "E:\source\repos\Eshop\eShop.Web\Views\Order\OrderHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc288d832c7ef65fa608526750f539a27b3a81df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_OrderHistory), @"mvc.1.0.view", @"/Views/Order/OrderHistory.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\source\repos\Eshop\eShop.Web\Views\_ViewImports.cshtml"
using eShop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\source\repos\Eshop\eShop.Web\Views\_ViewImports.cshtml"
using eShop.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc288d832c7ef65fa608526750f539a27b3a81df", @"/Views/Order/OrderHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b58a9c01cdb053ba4f231c1d3a4616a65246b766", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_OrderHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OrderModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div style=""margin:30px;"">
    <h3>შეკვეთები</h3>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">სტატუსი</th>
                <th scope=""col"">ფასი</th>
                <th scope=""col"">თარიღი</th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 16 "E:\source\repos\Eshop\eShop.Web\Views\Order\OrderHistory.cshtml"
              int iteration = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\source\repos\Eshop\eShop.Web\Views\Order\OrderHistory.cshtml"
             foreach (var item in Model)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 21 "E:\source\repos\Eshop\eShop.Web\Views\Order\OrderHistory.cshtml"
                               Write(iteration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 22 "E:\source\repos\Eshop\eShop.Web\Views\Order\OrderHistory.cshtml"
                   Write(item.OrderStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>$");
#nullable restore
#line 23 "E:\source\repos\Eshop\eShop.Web\Views\Order\OrderHistory.cshtml"
                    Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "E:\source\repos\Eshop\eShop.Web\Views\Order\OrderHistory.cshtml"
                   Write(item.DateCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 809, "\"", 843, 3);
            WriteAttributeValue("", 819, "OrderHistory(\'", 819, 14, true);
#nullable restore
#line 26 "E:\source\repos\Eshop\eShop.Web\Views\Order\OrderHistory.cshtml"
WriteAttributeValue("", 833, item.Id, 833, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 841, "\')", 841, 2, true);
            EndWriteAttribute();
            WriteLiteral(">დეტალურად</button>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 29 "E:\source\repos\Eshop\eShop.Web\Views\Order\OrderHistory.cshtml"
                iteration++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </tbody>
    </table>
</div>

<!--Category Modal -->

<div class=""modal fade"" tabindex=""-1"" role=""dialog"" data-backdrop=""static"" data-keyboard=""false"" id=""orderDetailsModal"">
    <div class=""modal-dialog modal-md"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title""></h5>
                <button type=""button"" class=""close"" data-bs-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
            </div>
            <div class=""modal-body"">
                <table class=""table table-striped"">
                    <thead>
                        <tr>
                            <th scope=""col"">#</th>
                            <th scope=""col"">პროდუქტი</th>
                            <th scope=""col"">რაოდენობა</th>
                            <th scope=""col"">ფასი</th>
                        </tr>
                    </thead>
               ");
            WriteLiteral("     <tbody>                       \r\n\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OrderModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
