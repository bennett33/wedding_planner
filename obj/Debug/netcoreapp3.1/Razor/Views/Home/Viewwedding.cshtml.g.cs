#pragma checksum "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "376507a67b89dd39fc3bcf719e9a9e5778be6acc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Viewwedding), @"mvc.1.0.view", @"/Views/Home/Viewwedding.cshtml")]
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
#line 1 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\_ViewImports.cshtml"
using wedding_planner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\_ViewImports.cshtml"
using wedding_planner.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"376507a67b89dd39fc3bcf719e9a9e5778be6acc", @"/Views/Home/Viewwedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a51918f518b1c660765b1690ff555606d20a50e8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Viewwedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h3 class=\"display-4\">");
#nullable restore
#line 8 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml"
                     Write(Model.WedderOne);

#line default
#line hidden
#nullable disable
            WriteLiteral(" and ");
#nullable restore
#line 8 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml"
                                          Write(Model.WedderTwo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s Wedding</h3>\r\n</div>\r\n<hr>\r\n<h4>Date: ");
#nullable restore
#line 11 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml"
     Write(Model.WeddingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n<div class=\"column-con\">\r\n    <div class=\"column\">\r\n        <h4>Guests:</h4>\r\n        <ul>\r\n");
#nullable restore
#line 17 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml"
             foreach(RSVP rsvp in Model.GuestList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>");
#nullable restore
#line 19 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml"
               Write(rsvp.guest.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 19 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml"
                                     Write(rsvp.guest.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 20 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n\r\n    <div class=\"column\">\r\n        <p>Address: ");
#nullable restore
#line 25 "C:\Users\Dragon\Desktop\Folders\Coding_Dojo1\CSharp_Stack\w3d2\wedding_planner\Views\Home\Viewwedding.cshtml"
               Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591