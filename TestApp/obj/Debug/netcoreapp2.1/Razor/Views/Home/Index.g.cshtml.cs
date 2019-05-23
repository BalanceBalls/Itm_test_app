#pragma checksum "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a85532ca80c12bfb021d27b4e50d69fb1e764a01"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\_ViewImports.cshtml"
using TestApp;

#line default
#line hidden
#line 2 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\_ViewImports.cshtml"
using TestApp.Models;

#line default
#line hidden
#line 3 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\_ViewImports.cshtml"
using TestApp.Models.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a85532ca80c12bfb021d27b4e50d69fb1e764a01", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bba59881cdc233a90883b9bb723603cebf8e054a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IpAddressModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeIpAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-anti-forgery", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "ITM Test";

#line default
#line hidden
            BeginContext(80, 160, true);
            WriteLiteral("\r\n<nav class=\"navbar navbar-light bg-light\">\r\n    <span class=\"navbar-brand mb-0 h1\">Список IP адресов в базе данных</span>\r\n</nav>\r\n\r\n<ul class=\"list-group\">\r\n");
            EndContext();
#line 11 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"
     foreach (var project in Model)
    {

#line default
#line hidden
            BeginContext(284, 60, true);
            WriteLiteral("        <li class=\"list-group-item active\"><b>Идентификатор ");
            EndContext();
            BeginContext(345, 10, false);
#line 13 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"
                                                       Write(project.Id);

#line default
#line hidden
            EndContext();
            BeginContext(355, 7, true);
            WriteLiteral("</b> : ");
            EndContext();
            BeginContext(363, 17, false);
#line 13 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"
                                                                         Write(project.IpAdderss);

#line default
#line hidden
            EndContext();
            BeginContext(380, 76, true);
            WriteLiteral("</li>\r\n        <li class=\"list-group-item\">\r\n            <div class=\"row\">\r\n");
            EndContext();
#line 16 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"
                 using (Html.BeginForm("RemoveIpAddress", "Home", FormMethod.Post))
                {


#line default
#line hidden
            BeginContext(562, 151, true);
            WriteLiteral("                    <div class=\"col-sm-2\" style=\"margin-right: 10px\">\r\n                        <input type=\"hidden\" id=\"ipAddressID\" name=\"ipAddressId\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 713, "", 731, 1);
#line 20 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 720, project.Id, 720, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(731, 119, true);
            WriteLiteral(">\r\n                        <input type=\"submit\" class=\"btn btn-danger\" value=\"Удалить\" />\r\n                    </div>\r\n");
            EndContext();
#line 23 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"

                }

#line default
#line hidden
            BeginContext(871, 95, true);
            WriteLiteral("                    <div class=\"col-sm-2\" style=\"margin-right: 10px\">\r\n                        ");
            EndContext();
            BeginContext(966, 445, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34dd5b1a36be47e983cffb1d707d210b", async() => {
                BeginContext(1047, 86, true);
                WriteLiteral("\r\n                            <input type=\"hidden\" id=\"ipAddressID\" name=\"ipAddressId\"");
                EndContext();
                BeginWriteAttribute("value", " value=", 1133, "", 1151, 1);
#line 27 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 1140, project.Id, 1140, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1151, 93, true);
                WriteLiteral(">\r\n                            <input type=\"hidden\" id=\"ipAddressVALUE\" name=\"ipAddressValue\"");
                EndContext();
                BeginWriteAttribute("value", " value=", 1244, "", 1269, 1);
#line 28 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 1251, project.IpAdderss, 1251, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1269, 135, true);
                WriteLiteral(">\r\n                            <button type=\"submit\" id=\"sendlogin\" class=\"btn btn-primary\">Изменить</button>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1411, 62, true);
            WriteLiteral("\r\n                    </div>\r\n            </div>\r\n     </li>\r\n");
            EndContext();
#line 34 "C:\Users\Alex\Documents\Visual Studio 2017\Projects\TestApp\TestApp\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1480, 5, true);
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IpAddressModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591