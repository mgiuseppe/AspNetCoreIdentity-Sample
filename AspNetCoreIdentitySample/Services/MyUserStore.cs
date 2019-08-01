using AspNetCoreIdentitySample.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreIdentitySample.Services
{
    public class MyUserStore : IUserStore<MyUserEntity>, IUserPasswordStore<MyUserEntity>
    {
        #region user

        public Task<string> GetNormalizedUserNameAsync(MyUserEntity user, CancellationToken cancellationToken) => Task.FromResult(user.NormalizedUserName);

        public Task<string> GetUserIdAsync(MyUserEntity user, CancellationToken cancellationToken) => Task.FromResult(user.Id);

        public Task<string> GetUserNameAsync(MyUserEntity user, CancellationToken cancellationToken) => Task.FromResult(user.UserName);

        public Task SetNormalizedUserNameAsync(MyUserEntity user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(MyUserEntity user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> CreateAsync(MyUserEntity user, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(MyUserEntity user, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(MyUserEntity user, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<MyUserEntity> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return Task.FromResult<MyUserEntity>(null);
        }

        public Task<MyUserEntity> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return Task.FromResult<MyUserEntity>(null);
        }

        #endregion

        #region password

        public Task<string> GetPasswordHashAsync(MyUserEntity user, CancellationToken cancellationToken) => Task.FromResult(user.PasswordHash);

        public Task<bool> HasPasswordAsync(MyUserEntity user, CancellationToken cancellationToken) => Task.FromResult(user.PasswordHash != null);

        public Task SetPasswordHashAsync(MyUserEntity user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        #endregion

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }
}
