// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WebApplication1.Pages.Shared.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\FavTeam.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\FavTeam.razor"
using Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\FavTeam.razor"
using WebApplication1.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\FavTeam.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\FavTeam.razor"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    public partial class FavTeam : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 95 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\FavTeam.razor"
       

    public dynamic res = null;
    public dynamic AllGames = new List<dynamic>();
    public dynamic soccer = new List<dynamic>();
    public dynamic basketball = new List<dynamic>();

    public dynamic searchList = new List<dynamic>();
    private bool loading = true;
    private string SearchValue = "";

    public bool isLoading = true;

    protected override async Task OnInitializedAsync()
    {
        var client = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://sportscore1.p.rapidapi.com/sports/1/teams?page=1"),
            Headers =
{
                            { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                            { "X-RapidAPI-Key", Global.API_KEY },
                        },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();


            res = JsonConvert.DeserializeObject(body);


            foreach (var item in res.data)
                soccer.Add(item);


        }

        //israel league
        request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://sportscore1.p.rapidapi.com/teams/search?section_id=183"),
            Headers =
{
                            { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                            { "X-RapidAPI-Key", Global.API_KEY },
                        },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();


            res = JsonConvert.DeserializeObject(body);


            foreach (var item in res.data)
                if (item.is_nationality != "true")
                    basketball.Add(item);
        }
        //nba
        request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://sportscore1.p.rapidapi.com/teams/search?section_id=168"),
            Headers =
{
                            { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                            { "X-RapidAPI-Key", Global.API_KEY },
                        },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();


            res = JsonConvert.DeserializeObject(body);


            foreach (var item in res.data)
                if (item.is_nationality != "true")
                    basketball.Add(item);
        }
        //euroleague
        request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://sportscore1.p.rapidapi.com/teams/search?section_id=182"),
            Headers =
{
                            { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                            { "X-RapidAPI-Key", Global.API_KEY },
                        },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();


            res = JsonConvert.DeserializeObject(body);


            foreach (var item in res.data)
                if (item.is_nationality != "true")
                    basketball.Add(item);
        }
        isLoading = false;
    }
    // nba = 7422,168 euro = 7473,182 israel = 7553,183


    public async void addFavTeam(dynamic id)
    {

        var user = await userManager.GetUserAsync(HttpContextAccessor.HttpContext.User);
        user.FavTeam = id.ToString();
        await userManager.UpdateAsync(user);        

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpContextAccessor HttpContextAccessor { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<ApplicationUser> userManager { get; set; }
    }
}
#pragma warning restore 1591
