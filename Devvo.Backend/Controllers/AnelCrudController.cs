namespace Devvo.Backend.Controllers;

using Devvo.Common.Model;
using Devvo.Common.DataTransferObject;
using Devvo.Backend.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

[Route("api/aneis")]
public class AnelCrudController: EntityCrudController<Anel, AnelDto>
{
    public AnelCrudController(ApplicationDbContext context, IMapper mapper): base(context, mapper)
    {
        
    }

    private ValidationResult? ValidateAneisCount(Anel anel)
    {
        // <Forjado Por, Máximo de anéis>
        var rules = new Dictionary<String, int>
        {
            { "SAURON", 1 },
            { "ELFOS", 3 },
            { "ANÕES", 7 },
            { "HOMENS", 9 },
        };

        var UPPERCASE_FORJADO_POR = anel.ForjadoPor.ToUpper();

        if (rules.ContainsKey(UPPERCASE_FORJADO_POR))
        {
            if (this.repository.Count(x => string.Equals(x.ForjadoPor, anel.ForjadoPor, StringComparison.CurrentCultureIgnoreCase)) >= rules[UPPERCASE_FORJADO_POR])
            {
                return new ValidationResult($"{anel.ForjadoPor} pode criar no máximo {rules[UPPERCASE_FORJADO_POR]} anel(éis).");
            }
        }

        return ValidationResult.Success;
    }

    protected override async Task<ValidationResult?> ValidateAddAsync(Anel anel)
    {
        return await Task.FromResult(this.ValidateAneisCount(anel));
    }

    protected override async Task<ValidationResult?> ValidateUpdateAsync(Anel current_anel, Anel new_anel)
    {
        // Uma alteração no nome do forjador pode infringir as regras das
        // quantidades máximas de anéis de cada forjador, por isso deve-se
        // checar se a alteração do nome não infringe tais regras.
        if (!string.Equals(current_anel.ForjadoPor, new_anel.ForjadoPor, StringComparison.CurrentCultureIgnoreCase))
        {
            return this.ValidateAneisCount(new_anel);
        }
        else
        {
            return await Task.FromResult(ValidationResult.Success);
        }
    }
}