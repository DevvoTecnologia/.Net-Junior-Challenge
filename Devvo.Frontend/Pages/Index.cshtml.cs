using System.Text.Json;
using Devvo.Common.DataTransferObject;
using Devvo.Frontend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devvo.Frontend.Pages;

[IgnoreAntiforgeryToken(Order = 2000)]
public class IndexModel : PageModel
{
    private readonly IEntityCrudService<AnelDto> service;

    [ViewData]
    public IEnumerable<AnelDto> Aneis { get; private set; } = [];

    public IndexModel(IEntityCrudService<AnelDto> service)
    {
        this.service = service;
    }

    public async Task OnGetAsync()
    {
        this.Aneis = await this.service.FindAllAsync();
    }

    public async Task<IActionResult> OnGetFindByIdAsync(string id)
    {
        return new JsonResult(await this.service.FindByIdAsync(id));
    }

    public async Task<IActionResult> OnPostAddAsync([FromBody] AnelDto anel)
    {
        var response = await this.service.AddAsync(anel);
        this.HttpContext.Response.StatusCode = (int) response.StatusCode;
        return Content(await response.Content.ReadAsStringAsync());
    }

    public async Task<IActionResult> OnPutUpdateAsync([FromBody] AnelDto anel)
    {
        var response = await this.service.UpdateAsync(anel);
        this.HttpContext.Response.StatusCode = (int) response.StatusCode;
        return Content(await response.Content.ReadAsStringAsync());
    }

    public async Task<IActionResult> OnDeleteRemoveByIdAsync(string id)
    {
        var response = await this.service.RemoveByIdAsync(id);
        this.HttpContext.Response.StatusCode = (int) response.StatusCode;
        return Content(await response.Content.ReadAsStringAsync());
    }
}
