#pragma checksum "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b649d4a47d53ca199d287e303be94ec2a3c5208d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
#line 1 "E:\source\repos\Eshop\eShop.Admin\Views\_ViewImports.cshtml"
using eShop.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\source\repos\Eshop\eShop.Admin\Views\_ViewImports.cshtml"
using eShop.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b649d4a47d53ca199d287e303be94ec2a3c5208d", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8feadb2409a34436c9a1ad2b3d0d19b8eaa9cbf4", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<eShop.Admin.Models.OrderModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<p>
    <!-- Button trigger modal -->
    <button type=""button"" class=""btn btn-success"" data-toggle=""modal"" data-target=""#orderModal"">შეკვეთის დამატება</button>

</p>

<table class=""table"">
    <thead>
        <tr>
            <th>
                ");
#nullable restore
#line 17 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 35 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 40 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.OrderStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <button class=\"btn btn-success btn-sm rounded-0\" type=\"button\" data-placement=\"top\" data-toggle=\"modal\" data-target=\"#orderModal\" title=\"რედაქტირება\" data-id=\"");
#nullable restore
#line 55 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
                                                                                                                                                                              Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""><i class=""fa fa-edit""></i></button>
                    <button class=""btn btn-danger btn-sm rounded-0"" type=""button"" data-toggle=""tooltip"" data-placement=""top"" title=""წაშლა""><i class=""fa fa-trash""></i></button>
                </td>
            </tr>
");
#nullable restore
#line 59 "E:\source\repos\Eshop\eShop.Admin\Views\Order\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<!--Role Modal -->
<div class=""modal"" id=""orderModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""orderModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""orderModalLabel"">შეკვეთის დამატება/რედაქტირება</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
            </div>
            <div class=""modal-body"">
                ....................
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">დახურვა</button>
                <button type=""submit"" class=""btn btn-success"">შენახვა</button>
            </div>
        </div>
    </div>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<eShop.Admin.Models.OrderModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591