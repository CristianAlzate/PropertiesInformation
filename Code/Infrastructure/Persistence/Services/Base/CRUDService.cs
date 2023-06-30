using AutoMapper;
using Core.Exceptions;
using Core.Interfaces.Base;
using Core.Interfaces.Services.Base;
using Core.Interfaces.Management;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Ardalis.GuardClauses;

namespace Infrastructure.Persistence.Services.Base
{
    public abstract class CRUDService<TGetDto, TAddDto, TUpdateDto, TKey, TEntity, TRepoAll, TContext> : ICRUDService<TGetDto, TAddDto, TUpdateDto, TKey, TEntity, TRepoAll, TContext>
      where TEntity : class, IEntityBase<TKey>
      where TRepoAll : IBaseRepository<TEntity, TContext>
      where TContext : DbContext, new()
    {
        internal readonly IMapper _mapper;
        internal readonly TRepoAll _repository;
        internal readonly IUnitOfWork<TContext> _unitOfWork;

        protected IMapper Mapper => _mapper;
        protected TRepoAll Repository => _repository;
        protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;

        public CRUDService(TRepoAll repository, IUnitOfWork<TContext> unitOfWork, IMapper mapper)
        {
            _repository = Guard.Against.Null(repository, nameof(repository));
            _mapper = Guard.Against.Null(mapper, nameof(mapper));
            _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
        }

        public async Task<TGetDto> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity getEntity = await _repository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<TGetDto>(getEntity);
        }

        public async Task<IEnumerable<TGetDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }

        public async Task<TAddDto> InsertAsync(TAddDto objDTO, CancellationToken cancellationToken = default)
        {
            TEntity addEntity = Mapper.Map<TEntity>(objDTO);
            await _repository.AddAsync(addEntity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Mapper.Map<TAddDto>(addEntity);
        }

        public async Task<TUpdateDto> UpdateAsync(TUpdateDto objDTO, CancellationToken cancellationToken = default)
        {
            TEntity updatedEntity = await _repository.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id), cancellationToken);

            if (updatedEntity == null)
                throw new EntityNotFoundException(typeof(TEntity), Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id));
            Mapper.Map(objDTO, updatedEntity);
            _repository.Update(updatedEntity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Mapper.Map<TUpdateDto>(updatedEntity);
        }

        public async Task<IEnumerable<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.FilterAsync(predicate, cancellationToken);
            return _mapper.Map<IEnumerable<TGetDto>>(list);
        }
    }
}
