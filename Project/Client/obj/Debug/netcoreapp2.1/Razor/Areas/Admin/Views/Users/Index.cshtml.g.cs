#pragma checksum "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5b8ef7652c6f70c5d1bf1e2a1d15fdd9f81b8e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Users/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Users_Index))]
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
#line 1 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#line 2 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5b8ef7652c6f70c5d1bf1e2a1d15fdd9f81b8e7", @"/Areas/Admin/Views/Users/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Users_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Client.Models.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(142, 630, true);
            WriteLiteral(@"



<main id=""main"" class=""main"">

    <div class=""pagetitle"">
        <h1>User</h1>
    </div><!-- End Page Title -->

    <section class=""section"">
        <div class=""row"">
            <div class=""col-lg-12"">

                <div class=""card"">
                    <div class=""card-body"">
                        <h5 class=""card-title"">Data Table</h5>

                        <!-- Default Table -->


                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th>
                                        ");
            EndContext();
            BeginContext(773, 40, false);
#line 32 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(813, 127, true);
            WriteLiteral("\r\n                                    </th>\r\n                                    <th>\r\n                                        ");
            EndContext();
            BeginContext(941, 41, false);
#line 35 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(982, 127, true);
            WriteLiteral("\r\n                                    </th>\r\n                                    <th>\r\n                                        ");
            EndContext();
            BeginContext(1110, 41, false);
#line 38 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(1151, 129, true);
            WriteLiteral("\r\n                                    </th>\r\n\r\n                                    <th>\r\n                                        ");
            EndContext();
            BeginContext(1281, 42, false);
#line 42 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(1323, 127, true);
            WriteLiteral("\r\n                                    </th>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1451, 44, false);
#line 45 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Birthday));

#line default
#line hidden
            EndContext();
            BeginContext(1495, 163, true);
            WriteLiteral("\r\n                                    </td>\r\n\r\n\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
            EndContext();
#line 52 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
            BeginContext(1755, 132, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(1888, 39, false);
#line 56 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1927, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2067, 40, false);
#line 59 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(2107, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2247, 40, false);
#line 62 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(2287, 177, true);
            WriteLiteral("\r\n                                        </td>\r\n                                    \r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2465, 41, false);
#line 66 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(2506, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2646, 43, false);
#line 69 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Birthday));

#line default
#line hidden
            EndContext();
            BeginContext(2689, 133, true);
            WriteLiteral("\r\n                                        </td>\r\n                                     \r\n\r\n                                    </tr>\r\n");
            EndContext();
#line 74 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Areas\Admin\Views\Users\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(2857, 247, true);
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                        <!-- End Default Table Example -->\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </section>\r\n\r\n</main>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Client.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
