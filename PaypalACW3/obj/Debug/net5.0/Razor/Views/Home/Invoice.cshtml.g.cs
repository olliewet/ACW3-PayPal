#pragma checksum "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37ad36e89fde4c1920266477a3f5495d9b51985c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Invoice), @"mvc.1.0.view", @"/Views/Home/Invoice.cshtml")]
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
#line 1 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\_ViewImports.cshtml"
using PaypalACW3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\_ViewImports.cshtml"
using PaypalACW3.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37ad36e89fde4c1920266477a3f5495d9b51985c", @"/Views/Home/Invoice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3783b7e87a567c397de38aac310f43db647b4aa7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Invoice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Invoice>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
  
    ViewData["Title"] = "Invoice";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 11 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            WriteLiteral("\r\n<html>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37ad36e89fde4c1920266477a3f5495d9b51985c4006", async() => {
                WriteLiteral(@"


    <!--- Total Price Table -->
    <article class=""tile notification is-white"" style=""box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; margin-left: 15px;"">
        <table class=""table"">
            <thead>
                <tr>


                    <th scope=""col""> Name</th>

");
#nullable restore
#line 30 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
                     if (Model.PayPalOrderID != null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <th scope=\"col\">Paypal Order ID</th>\r\n");
#nullable restore
#line 33 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <th scope=\"col\">Invoice Number </th>\r\n                    <th scope=\"col\">Amount Payed </th>\r\n                </tr>\r\n            </thead>\r\n\r\n            <tbody>\r\n            <tr>\r\n                    <td>");
#nullable restore
#line 41 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n");
#nullable restore
#line 42 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
                     if (Model.PayPalOrderID != null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>");
#nullable restore
#line 44 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
                       Write(Model.PayPalOrderID);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n");
#nullable restore
#line 45 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td>");
#nullable restore
#line 46 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
                   Write(Model.invoiceNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n                    <td>£");
#nullable restore
#line 47 "C:\Users\Ollie\Desktop\Work\Year 4\TrustWorthy Computing\ACW 3\PaypalACW3\ACW3PayPal\PaypalACW3\Views\Home\Invoice.cshtml"
                    Write(Model.amountPayed);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n                </tr>\r\n\r\n            </tbody>\r\n        </table>\r\n    </article>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Invoice> Html { get; private set; }
    }
}
#pragma warning restore 1591
