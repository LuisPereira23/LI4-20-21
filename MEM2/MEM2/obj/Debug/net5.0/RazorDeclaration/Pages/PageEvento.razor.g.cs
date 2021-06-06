// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace MEM2.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using MEM2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\LI4\MEM2\MEM2\MEM2\_Imports.razor"
using MEM2.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\LI4\MEM2\MEM2\MEM2\Pages\PageEvento.razor"
using MEM2.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\LI4\MEM2\MEM2\MEM2\Pages\PageEvento.razor"
using MEM2.Data.MEM2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\LI4\MEM2\MEM2\MEM2\Pages\PageEvento.razor"
using System.Diagnostics;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/EventoDetails/{Id}")]
    public partial class PageEvento : OwningComponentBase<EventoService>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 63 "F:\LI4\MEM2\MEM2\MEM2\Pages\PageEvento.razor"
      

    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }


    [Parameter]
    public string Id { get; set; }

    Evento Evento = new Evento();

    private bool load = false;
    Boolean on;

    protected override async Task OnInitializedAsync()
    {
        Evento = await @Service.GetEvento(int.Parse(Id));
        load = true;

        var user = (await authenticationStateTask).User;

        if (user.Identity.IsAuthenticated)
        {
            bool On = Service.IsFollowing(user.Identity.Name, Evento.Id);
            on = On;
        }
    }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {


        if (load)
        {
            await JS.InvokeVoidAsync("loadBingMap", Evento.Latitude, Evento.Longitude);
            load = false;
        }


    }



    protected async Task FollowFunction()
    {

        var user = (await authenticationStateTask).User;
        Service.SetSeguido(user.Identity.Name, Evento.Id, on);
        on = !on;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
    }
}
#pragma warning restore 1591
