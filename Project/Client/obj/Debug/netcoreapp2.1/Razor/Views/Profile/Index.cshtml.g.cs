#pragma checksum "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f9a891c83ed5e0060e76c6b9dc448bbebccb7f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Index), @"mvc.1.0.view", @"/Views/Profile/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Profile/Index.cshtml", typeof(AspNetCore.Views_Profile_Index))]
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
#line 1 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#line 2 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f9a891c83ed5e0060e76c6b9dc448bbebccb7f9", @"/Views/Profile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Client.Models.User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:300px;height:450px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(130, 311, true);
            WriteLiteral(@"<section class=""banner-area relative"" id=""home"">
    <div class=""overlay overlay-bg""></div>
    <div class=""container"">
        <div class=""row d-flex align-items-center justify-content-center"">
            <div class=""about-content col-lg-12"">
                <h1 class=""text-white"">
                    ");
            EndContext();
            BeginContext(442, 12, false);
#line 13 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml"
               Write(ViewBag.user);

#line default
#line hidden
            EndContext();
            BeginContext(454, 666, true);
            WriteLiteral(@"
                </h1>
                <p class=""text-white""><a href=""index.html"">Home </a>  <span class=""lnr lnr-arrow-right""></span>  <a href=""contact.html""> Contact Us</a></p>
            </div>
        </div>
    </div>
</section>
<section class=""bg-light"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12 mb-4 mb-sm-5"">
                <div class=""card card-style1 border-0"">
                    <div class=""card-body p-1-9 p-sm-2-3 p-md-6 p-lg-7"">
                        <div class=""row align-items-center"">
                            <div class=""col-lg-6 mb-4 mb-lg-0"">
                                ");
            EndContext();
            BeginContext(1120, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4f9a891c83ed5e0060e76c6b9dc448bbebccb7f96657", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1164, "~/images/", 1164, 9, true);
#line 28 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml"
AddHtmlAttributeValue("", 1173, ViewBag.user.Image, 1173, 19, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1204, 281, true);
            WriteLiteral(@"
                            </div>
                            <div class=""col-lg-6 px-xl-10"">
                                <div class=""bg-secondary d-lg-inline-block py-1-9 px-1-9 px-sm-6 mb-1-9 rounded"">
                                    <h3 class=""h2 text-white mb-0"">");
            EndContext();
            BeginContext(1486, 17, false);
#line 32 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml"
                                                              Write(ViewBag.user.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1503, 306, true);
            WriteLiteral(@"</h3>
                                </div>
                                <br />

                                <ul class=""list-unstyled mb-1-9"">
                                    <li class=""mb-2 mb-xl-3 display-28""><span class=""display-26 text-secondary me-2 font-weight-600"">Username:</span> ");
            EndContext();
            BeginContext(1810, 21, false);
#line 37 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml"
                                                                                                                                                 Write(ViewBag.user.Username);

#line default
#line hidden
            EndContext();
            BeginContext(1831, 154, true);
            WriteLiteral("</li>\r\n                                    <li class=\"mb-2 mb-xl-3 display-28\"><span class=\"display-26 text-secondary me-2 font-weight-600\">Phone:</span> ");
            EndContext();
            BeginContext(1986, 18, false);
#line 38 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml"
                                                                                                                                              Write(ViewBag.user.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(2004, 153, true);
            WriteLiteral("</li>\r\n                                    <li class=\"mb-2 mb-xl-3 display-28\"><span class=\"display-26 text-secondary me-2 font-weight-600\">Email:</span>");
            EndContext();
            BeginContext(2158, 18, false);
#line 39 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml"
                                                                                                                                             Write(ViewBag.user.Email);

#line default
#line hidden
            EndContext();
            BeginContext(2176, 157, true);
            WriteLiteral("</li>\r\n                                    <li class=\"mb-2 mb-xl-3 display-28\"><span class=\"display-26 text-secondary me-2 font-weight-600\">Birthday:</span> ");
            EndContext();
            BeginContext(2334, 21, false);
#line 40 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml"
                                                                                                                                                 Write(ViewBag.user.Birthday);

#line default
#line hidden
            EndContext();
            BeginContext(2355, 78, true);
            WriteLiteral("</li>\r\n                                </ul>\r\n                                ");
            EndContext();
            BeginContext(2433, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f9a891c83ed5e0060e76c6b9dc448bbebccb7f912081", async() => {
                BeginContext(2510, 14, true);
                WriteLiteral("Update Account");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 42 "C:\Users\DatNguyen\Desktop\EProject (1)\EProject\Group1_C2009I12_eProject_Sem3\Project\Client\Views\Profile\Index.cshtml"
                                                                               WriteLiteral(ViewBag.user.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2528, 5112, true);
            WriteLiteral(@"
                                <ul class=""social-icon-style1 list-unstyled mb-0 ps-0"">
                                    <li><a href=""#!""><i class=""ti-twitter-alt""></i></a></li>
                                    <li><a href=""#!""><i class=""ti-facebook""></i></a></li>
                                    <li><a href=""#!""><i class=""ti-pinterest""></i></a></li>
                                    <li><a href=""#!""><i class=""ti-instagram""></i></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-12 mb-4 mb-sm-5"">
                <div>
                    <span class=""section-title text-primary mb-3 mb-sm-4"">About Me</span>
                    <p>Edith is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and s");
            WriteLiteral(@"crambled it to make a type specimen book.</p>
                    <p class=""mb-0"">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed.</p>
                </div>
            </div>
            <div class=""col-lg-12"">
                <div class=""row"">
                    <div class=""col-lg-12 mb-4 mb-sm-5"">
                        <div class=""mb-4 mb-sm-5"">
                            <span class=""section-title text-primary mb-3 mb-sm-4"">Skill</span>
                            <div class=""progress-text"">
                                <div class=""row"">
                                    <div class=""col-6"">Driving range</div>
                                    <div class=""col-6 text-end"">80%</div>
                                </div>
                            </div>
                            <div class=""custom-pr");
            WriteLiteral(@"ogress progress progress-medium mb-3"" style=""height: 4px;"">
                                <div class=""animated custom-bar progress-bar slideInLeft bg-secondary"" style=""width:80%"" aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""10"" role=""progressbar""></div>
                            </div>
                            <div class=""progress-text"">
                                <div class=""row"">
                                    <div class=""col-6"">Short Game</div>
                                    <div class=""col-6 text-end"">90%</div>
                                </div>
                            </div>
                            <div class=""custom-progress progress progress-medium mb-3"" style=""height: 4px;"">
                                <div class=""animated custom-bar progress-bar slideInLeft bg-secondary"" style=""width:90%"" aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""70"" role=""progressbar""></div>
                            </div>
                            <div class=");
            WriteLiteral(@"""progress-text"">
                                <div class=""row"">
                                    <div class=""col-6"">Side Bets</div>
                                    <div class=""col-6 text-end"">50%</div>
                                </div>
                            </div>
                            <div class=""custom-progress progress progress-medium mb-3"" style=""height: 4px;"">
                                <div class=""animated custom-bar progress-bar slideInLeft bg-secondary"" style=""width:50%"" aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""70"" role=""progressbar""></div>
                            </div>
                            <div class=""progress-text"">
                                <div class=""row"">
                                    <div class=""col-6"">Putting</div>
                                    <div class=""col-6 text-end"">60%</div>
                                </div>
                            </div>
                            <div class=""custom-progr");
            WriteLiteral(@"ess progress progress-medium"" style=""height: 4px;"">
                                <div class=""animated custom-bar progress-bar slideInLeft bg-secondary"" style=""width:60%"" aria-valuemax=""100"" aria-valuemin=""0"" aria-valuenow=""70"" role=""progressbar""></div>
                            </div>
                        </div>
                        <div>
                            <span class=""section-title text-primary mb-3 mb-sm-4"">Education</span>
                            <p>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.</p>
                            <p class=""mb-1-9"">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour.</p>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
");
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
