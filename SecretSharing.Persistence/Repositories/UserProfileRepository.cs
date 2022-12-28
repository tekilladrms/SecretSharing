using Microsoft.EntityFrameworkCore;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using SecretSharing.Persistence.Exceptions;
using SecretSharing.Persistence.Specifications;
using SecretSharing.Persistence.Specifications.UserProfileSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public UserProfileRepository(ApplicationDbContext context) => _context = context;


        public async Task<IEnumerable<UserProfile>> GetAllBySpecificationAsync(
            Specification<UserProfile> specification,
            CancellationToken cancellationToken = default) =>
            await ApplySpecification(specification)
            .ToListAsync(cancellationToken);
        

        public async Task<UserProfile> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var userProfile = await _context.Set<UserProfile>().FirstOrDefaultAsync(user => user.Guid == id);

            if (userProfile is null) throw new NotFoundPersistencseException($"UserProfile with id = {id} was not found");

            return userProfile;
        }

        public async Task<UserProfile> GetByIdWithDocumentsAsync(
            Guid id, CancellationToken cancellationToken = default) =>
            await ApplySpecification(new UserByIdWithDocumentsSpecification(id))
            .FirstOrDefaultAsync(cancellationToken);


        public async Task<Guid> AddAsync(UserProfile entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<UserProfile>().AddAsync(entity);
            return entity.Guid;
        }

        public async Task<UserProfile> Update(UserProfile entity, CancellationToken cancellationToken = default)
        {
            _context.Set<UserProfile>().Update(entity);
            return await GetByIdAsync(entity.Guid);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            _context.Remove(await GetByIdAsync(id));
        }

        private IQueryable<UserProfile> ApplySpecification(Specification<UserProfile> specification)
        {
            return SpecificationEvaluator.GetQuery(
                _context.Set<UserProfile>(),
                specification);
        }

        
    }
}
