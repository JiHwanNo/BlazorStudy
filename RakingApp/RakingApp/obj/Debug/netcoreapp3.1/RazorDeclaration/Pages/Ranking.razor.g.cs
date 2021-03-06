// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace RakingApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\_Imports.razor"
using RakingApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\_Imports.razor"
using RakingApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\Pages\Ranking.razor"
using ShareData.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\Pages\Ranking.razor"
using RakingApp.Data.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/ranking")]
    public partial class Ranking : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 85 "C:\Users\lg\Documents\GitHub\BlazorStudy\RakingApp\RakingApp\Pages\Ranking.razor"
       
    List<GameResult> _gameResults;

    bool _showPopup;
    GameResult _gameResult;
    protected override async Task OnInitializedAsync()
    {
        _gameResults = await _RankingService.GetGameResultsAsyc();
    }
    void AddGameResult()
    {
        _showPopup = true;
        _gameResult = new GameResult() { Id = 0 };
    }

    void ClosePopup()
    {
        _showPopup = false;
    }

    async Task UpdateGameResult(GameResult gameResult)
    {
        _showPopup = true;
        _gameResult = gameResult;
    }

    async Task DeleteGameResult(GameResult gameResult)
    {
        var result = _RankingService.DeleteGameResult(gameResult);

        _gameResults = await _RankingService.GetGameResultsAsyc();
    }

    async Task SaveGameResult()
    {
        if(_gameResult.Id ==0)
        {
            _gameResult.Date = DateTime.Now;
            var result = await  _RankingService.AddGameResult(_gameResult);
        }
        else
        {
            var retsult = await _RankingService.UpdateGameResult(_gameResult);
        }

        _gameResults = await _RankingService.GetGameResultsAsyc();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RankingService _RankingService { get; set; }
    }
}
#pragma warning restore 1591
