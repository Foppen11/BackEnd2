#pragma checksum "C:\Users\MaxFo\Desktop\NyBackEndInlamning\Inlamning1\Inlamning2\Views\User\VerifyLogin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8195b1a78a6a698bd11f8b6b93d2133d2de0f0a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_VerifyLogin), @"mvc.1.0.view", @"/Views/User/VerifyLogin.cshtml")]
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
#line 1 "C:\Users\MaxFo\Desktop\NyBackEndInlamning\Inlamning1\Inlamning2\Views\_ViewImports.cshtml"
using Inlamning2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MaxFo\Desktop\NyBackEndInlamning\Inlamning1\Inlamning2\Views\_ViewImports.cshtml"
using Inlamning2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8195b1a78a6a698bd11f8b6b93d2133d2de0f0a0", @"/Views/User/VerifyLogin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2e5e453a769e264e0565abd86e838199ac17ad4", @"/Views/_ViewImports.cshtml")]
    public class Views_User_VerifyLogin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Inlamning2.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\MaxFo\Desktop\NyBackEndInlamning\Inlamning1\Inlamning2\Views\User\VerifyLogin.cshtml"
  
    ViewData["Title"] = "VerifyLogin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>User logged in: ");
#nullable restore
#line 7 "C:\Users\MaxFo\Desktop\NyBackEndInlamning\Inlamning1\Inlamning2\Views\User\VerifyLogin.cshtml"
               Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Inlamning2.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
