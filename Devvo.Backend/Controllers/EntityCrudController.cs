namespace Devvo.Backend.Controllers;

using Devvo.Common.Model;
using Devvo.Backend.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

[ApiController]
public class EntityCrudController<TEntity, TEntityDto>: ControllerBase where TEntity: class, IEntity
{
    protected readonly IEntityRepository<TEntity> repository;
    protected readonly IMapper mapper;

    public EntityCrudController(ApplicationDbContext context, IMapper mapper)
    {
        this.repository = new EntityRepository<TEntity>(context);
        this.mapper = mapper;
    }

    /// <summary>
    /// Lista todas as entidades cadastradas no banco de dados.
    /// </summary>
    /// <returns>Uma lista contendo as entidades cadastradas</returns>
    /// <response code="200">Operação realizada com sucesso</response>
    [HttpGet]
    [Produces("application/json")]
    public virtual async Task<IActionResult> FindAllAsync()
    {
        return Ok(this.mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityDto>>(await this.repository.FindAllAsync()));
    }

    /// <summary>
    /// Obtém uma única entidade do banco de dados a partir de seu Guid.
    /// </summary>
    /// <returns>A entidade com o Guid solicitado</returns>
    /// <response code="200">Entidade localizada e retornada com sucesso</response>
    /// <response code="404">Entidade não localizada</response>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    public virtual async Task<IActionResult> FindByIdAsync([FromRoute] Guid id)
    {
        var entity = await this.repository.FindByIdAsync(id);
        if (entity != null)
        {
            return Ok(this.mapper.Map<TEntityDto>(entity));
        }
        else
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Cadastra uma única entidade do banco de dados.
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     POST /api/aneis
    ///     {
    ///        "Nome": "Narya, o anel do fogo",
    ///        "Poder": "Seu portador ganha resistência ao fogo",
    ///        "Portador": "Gandalf",
    ///        "ForjadoPor": "Elfos",
    ///        "Imagem": "/images/one_ring_1.png"
    ///     }
    ///
    /// </remarks>
    /// <param name="data">Dados da entidade a ser cadastrada</param>
    /// <response code="200">Entidade cadastrada sucesso</response>
    /// <response code="400">Dados no formato incorreto</response>
    /// <response code="422">Erro na validação do cadastro da entidade</response>
    [HttpPost]
    [Consumes("application/json")]
    public virtual async Task<IActionResult> AddAsync([FromBody] TEntityDto data)
    {
        var entity = this.mapper.Map<TEntity>(data);
        // Id não deve ser informado no objeto da requisição.
        if (await this.repository.FindByIdAsync(entity.Id) == null)
        {
            var validation = await this.ValidateAddAsync(entity);
            if (validation == ValidationResult.Success)
            {
                await this.repository.AddAsync(entity);
                await this.repository.SaveAsync();
                return Ok();
            }
            else
            {
                return UnprocessableEntity(validation);
            }
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Atualiza os dados de uma única entidade do banco de dados.
    /// </summary>
    /// <remarks>
    /// Exemplo:
    ///
    ///     PUT /api/aneis
    ///     {
    ///        "Id": "8681eb24-bb1c-4c93-8d08-37990cb3edbb",
    ///        "Nome": "Narya, o anel do fogo",
    ///        "Poder": "Seu portador ganha resistência ao fogo",
    ///        "Portador": "Gandalf",
    ///        "ForjadoPor": "Elfos",
    ///        "Imagem": "/images/one_ring_1.png"
    ///     }
    ///
    /// </remarks>
    /// <param name="data">Dados da entidade a ser atualizada</param>
    /// <response code="200">Entidade atualizada sucesso</response>
    /// <response code="400">Dados no formato incorreto</response>
    /// <response code="404">Entidade a ser atualizada não está cadastrada</response>
    /// <response code="422">Erro na validação do cadastro da entidade</response>
    [HttpPut]
    [Consumes("application/json")]
    public virtual async Task<IActionResult> UpdateAsync([FromBody] TEntityDto data)
    {
        var new_entity = this.mapper.Map<TEntity>(data);
        var old_entity = await this.repository.FindByIdAsync(new_entity.Id);
        if (old_entity != null)
        {
            var validation = await this.ValidateUpdateAsync(old_entity, new_entity);
            if (validation == ValidationResult.Success)
            {
                this.repository.Update(new_entity);
                await this.repository.SaveAsync();
                return Ok();
            }
            else
            {
                return UnprocessableEntity(validation);
            }
        }
        else
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Remove uma única entidade do banco de dados a partir de seu Guid.
    /// </summary>
    /// <response code="200">Entidade localizada e retornada com sucesso</response>
    [HttpDelete("{id:guid}")]
    public virtual async Task<IActionResult> RemoveByIdAsync([FromRoute] Guid id)
    {
        var entity = await this.repository.FindByIdAsync(id);
        if (entity != null)
        {
            await this.repository.RemoveByIdAsync(id);
            await this.repository.SaveAsync();
        }
        // Método DELETE é idempotente, logo se a entidade não existir
        // não devemos retornar um erro.
        return Ok();
    }

    /// <summary>
    /// Método utilizado pela função AddAsync para validar os dados da entidade
    /// a ser cadastrada antes de incluí-la no banco de dados.
    /// </summary>
    protected virtual async Task<ValidationResult?> ValidateAddAsync(TEntity entity)
    {
        return await Task.FromResult(ValidationResult.Success);
    }

    /// <summary>
    /// Método utilizado pela função UpdateAsync para validar os dados da entidade
    /// a ser atualizada no banco de dados.
    /// </summary>
    protected virtual async Task<ValidationResult?> ValidateUpdateAsync(TEntity current_entity, TEntity new_entity)
    {
        return await Task.FromResult(ValidationResult.Success);
    }
}