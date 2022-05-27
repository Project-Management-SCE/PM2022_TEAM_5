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
#line 1 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\Leagues.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\Leagues.razor"
using Components;

#line default
#line hidden
#nullable disable
    public partial class Leagues : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 403 "C:\Users\Eliran\Desktop\Sport api\PM2022_TEAM_5-main\WebApplication1\WebApplication1\Pages\Shared\Components\Leagues.razor"
       

    public Dictionary<string, string> leaguesLogo = new Dictionary<string, string>();
    public Dictionary<string, string> leaguesID = new Dictionary<string, string>();
    public dynamic PL = new List<dynamic>();
    public dynamic BundesLig = new List<dynamic>();
    public dynamic IsraelFootball = new List<dynamic>();
    public dynamic Laliga = new List<dynamic>();
    public dynamic IsraelBasketball = new List<dynamic>();
    public dynamic Euroleague = new List<dynamic>();
    public dynamic NBA = new List<dynamic>();
    public dynamic SeriaA = new List<dynamic>();

    void initializeLogos()
    {
        leaguesLogo.Add("PL", "https://i.pinimg.com/736x/53/de/94/53de9461519de82c39b132aac9a74338.jpg");
        leaguesLogo.Add("BundesLig", "https://upload.wikimedia.org/wikipedia/en/d/df/Bundesliga_logo_%282017%29.svg");
        leaguesLogo.Add("Seria A", "https://seeklogo.com/images/L/lega-serie-a-logo-F6AA6C64C9-seeklogo.com.png");
        //leaguesLogo.Add("League1", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Ligue1.svg/1200px-Ligue1.svg.png");
        leaguesLogo.Add("IsraelFootball", "https://upload.wikimedia.org/wikipedia/en/c/c4/Israeli_Premier_League.png");
        leaguesLogo.Add("Laliga", "https://iscreativestudio.com/wp-content/uploads/2016/08/logotipos4.jpg");
        leaguesLogo.Add("IsraelBasketball", "https://www.uleb.com/images/leagues/logo/11/israel-basketball-super-league.jpg?t=1643827081");
        leaguesLogo.Add("Euroleague", "https://i.pinimg.com/originals/99/68/5e/99685e3f066e5d3d4e4daa6196af9778.jpg");
        leaguesLogo.Add("NBA", "https://andscape.com/wp-content/uploads/2017/06/nbalogo.jpg?w=700");

    }

    void initializeID()
    {
        leaguesID.Add("PL", "11320");
        leaguesID.Add("BundesLig", "9038");
        leaguesID.Add("IsraelFootball", "9170");
        leaguesID.Add("Laliga", "9080");
        leaguesID.Add("IsraelBasketball", "11328");
        leaguesID.Add("Euroleague", "9300");
        leaguesID.Add("NBA", "10345");
        leaguesID.Add("SeriaA", "9299");

    }

    public List<dynamic> Sort(dynamic input)
    {
        List<dynamic> temp = new List<dynamic>();
        int size = input.Count;
        int i = 1;

        while (i < (size + 1))
        {
            foreach (var item in input)
            {
                int position = item.position;
                if (position == i)
                {
                    temp.Add(item);
                    i++;
                    continue;
                }
            }
        }
        return temp;
    }

    async Task initializeLeagues()
    {
        PL = await GetLeague("8960");
        SeriaA = await GetLeague("9299");
        BundesLig = await GetLeague("9038");
        IsraelFootball = await GetLeague("9170");
        Laliga = await GetLeague("9080");
        IsraelBasketball = await GetLeague("11328");
        Euroleague = await GetLeague("9300");
        NBA = await GetLeague("10345");
    }


    protected override async Task OnInitializedAsync()
    {
        initializeLogos();
        initializeID();
        await initializeLeagues();
    }

    public async Task<List<dynamic>> GetLeague(dynamic id)
    {
        dynamic res = null;
        string uri = "https://sportscore1.p.rapidapi.com/seasons/" + id + "/standings-tables";

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uri),
            Headers =
{
        { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
        { "X-RapidAPI-Key",WebApplication1.Model.Global.API_KEY },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            res = JsonConvert.DeserializeObject(body);


        }
        return Sort(res.data[0].standings_rows);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591