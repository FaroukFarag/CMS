using AutoMapper;
using CMS.Application.Dtos.Abstraction;
using CMS.Application.Interfaces.Abstraction;
using CMS.Domain.Interfaces.Repositories.Abstraction;
using CMS.Domain.Interfaces.UnitOfWork;
using CMS.Domain.Models.Abstraction;

namespace CMS.Application.Services.Abstraction;

public abstract class BaseService<T, TDto> : IBaseService<TDto>
    where T : BaseModel
    where TDto : BaseModelDto
{
    private readonly IBaseRepository<T> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BaseService(
        IBaseRepository<T> repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public virtual async Task<TDto> CreateAsync(TDto entityDto)
    {
        var entity = _mapper.Map<T>(entityDto);

        await _repository.CreateAsync(entity);

        await _unitOfWork.Complete();

        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> GetAsync(int id)
    {
        var entity = await _repository.GetAsync(id);
        var entityDto = _mapper.Map<TDto>(entity);

        return entityDto;
    }

    public virtual async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        var entitiesDtos = _mapper.Map<IReadOnlyList<TDto>>(entities);

        return entitiesDtos;
    }

    public virtual async Task<TDto> Update(TDto newEntityDto)
    {
        var entity = _mapper.Map<T>(newEntityDto);

        _repository.Update(entity);

        await _unitOfWork.Complete();

        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> Delete(int id)
    {
        var entity = _repository.Delete(id);
        var entityDto = _mapper.Map<TDto>(entity);

        await _unitOfWork.Complete();

        return entityDto;
    }
}
