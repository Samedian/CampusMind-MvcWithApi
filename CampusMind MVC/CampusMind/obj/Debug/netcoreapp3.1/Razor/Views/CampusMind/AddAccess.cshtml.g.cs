#pragma checksum "C:\Users\Samarth\source\repos\CampusMind\CampusMind\Views\CampusMind\AddAccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80fe4d40461c13fa82ab7816be70ce3ee15009d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CampusMind_AddAccess), @"mvc.1.0.view", @"/Views/CampusMind/AddAccess.cshtml")]
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
#line 1 "C:\Users\Samarth\source\repos\CampusMind\CampusMind\Views\_ViewImports.cshtml"
using CampusMind;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Samarth\source\repos\CampusMind\CampusMind\Views\_ViewImports.cshtml"
using CampusMind.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80fe4d40461c13fa82ab7816be70ce3ee15009d9", @"/Views/CampusMind/AddAccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"913f4b7c1a48a6381aae444b5f8428480dc8259f", @"/Views/_ViewImports.cshtml")]
    public class Views_CampusMind_AddAccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CampusMind.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE HTML>\r\n");
#nullable restore
#line 3 "C:\Users\Samarth\source\repos\CampusMind\CampusMind\Views\CampusMind\AddAccess.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""form-group"">
    <label for=""UserName"">User Name</label>
    <input type=""text"" class=""form-control"" id=""UserName"" placeholder=""Enter User Name"">
</div>
<div class=""form-group"">
    <label for=""Password"">Password</label>
    <input type=""text"" class=""form-control"" id=""Password"" placeholder=""Password"">
</div>
<div class=""form-group"">
    <label for=""RoleAssign"">Role Assign</label>
    <input type=""text"" class=""form-control"" id=""RoleAssign"" placeholder=""Role Assign"">
</div>
<button type=""submit"" class=""btn btn-primary"" id=""btnSave"">Submit</button>

");
#nullable restore
#line 21 "C:\Users\Samarth\source\repos\CampusMind\CampusMind\Views\CampusMind\AddAccess.cshtml"
Write(Html.ActionLink("Menu", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
    $(function () {
    $(""#btnSave"").click(function () {
        var user = {};
        user.UserName = $(""#UserName"").val();
        user.Password = $(""#Password"").val();
        user.RoleAssign = $(""#RoleAssign"").val();

    $.ajax({
         type: ""POST"",
        url: '");
#nullable restore
#line 34 "C:\Users\Samarth\source\repos\CampusMind\CampusMind\Views\CampusMind\AddAccess.cshtml"
         Write(Url.Action("AddAccess"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
        data: user,
         //data: '{access: ' + JSON.stringify(access) + '}',
        // dataType: ""json"",
        //contentType: ""application/json; charset=utf-8"",
        success: function () {
           alert(""Data has been added successfully."");

        },
        error: function () {
        alert(""Error while inserting data"");
        }
    });

    return false;
    });
    });
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CampusMind.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591