using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Application.Managers;

using Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Managers
{
	internal class UserManager : UserManager<AppUser>, IUserManager
	{
		public UserManager(IUserStore<AppUser> store,
			IOptions<IdentityOptions> optionsAccessor,
			IPasswordHasher<AppUser> passwordHasher,
			IEnumerable<IUserValidator<AppUser>> userValidators,
			IEnumerable<IPasswordValidator<AppUser>> passwordValidators,
			ILookupNormalizer keyNormalizer,
			IdentityErrorDescriber errors,
			IServiceProvider services,
			ILogger<UserManager<AppUser>> logger) : base(store,
				optionsAccessor,
				passwordHasher,
				userValidators,
				passwordValidators,
				keyNormalizer,
				errors,
				services,
				logger)
		{
		}

		public override ILogger Logger { get => base.Logger; set => base.Logger = value; }

		public override bool SupportsUserAuthenticationTokens => base.SupportsUserAuthenticationTokens;

		public override bool SupportsUserAuthenticatorKey => base.SupportsUserAuthenticatorKey;

		public override bool SupportsUserTwoFactorRecoveryCodes => base.SupportsUserTwoFactorRecoveryCodes;

		public override bool SupportsUserTwoFactor => base.SupportsUserTwoFactor;

		public override bool SupportsUserPassword => base.SupportsUserPassword;

		public override bool SupportsUserSecurityStamp => base.SupportsUserSecurityStamp;

		public override bool SupportsUserRole => base.SupportsUserRole;

		public override bool SupportsUserLogin => base.SupportsUserLogin;

		public override bool SupportsUserEmail => base.SupportsUserEmail;

		public override bool SupportsUserPhoneNumber => base.SupportsUserPhoneNumber;

		public override bool SupportsUserClaim => base.SupportsUserClaim;

		public override bool SupportsUserLockout => base.SupportsUserLockout;

		public override bool SupportsQueryableUsers => base.SupportsQueryableUsers;

		public override IQueryable<AppUser> Users => base.Users;

		protected override CancellationToken CancellationToken => base.CancellationToken;

		public override Task<IdentityResult> AccessFailedAsync(AppUser user)
		{
			return base.AccessFailedAsync(user);
		}

		public override Task<IdentityResult> AddClaimAsync(AppUser user, Claim claim)
		{
			return base.AddClaimAsync(user, claim);
		}

		public override Task<IdentityResult> AddClaimsAsync(AppUser user, IEnumerable<Claim> claims)
		{
			return base.AddClaimsAsync(user, claims);
		}

		public override Task<IdentityResult> AddLoginAsync(AppUser user, UserLoginInfo login)
		{
			return base.AddLoginAsync(user, login);
		}

		public override Task<IdentityResult> AddPasswordAsync(AppUser user, string password)
		{
			return base.AddPasswordAsync(user, password);
		}

		public override Task<IdentityResult> AddToRoleAsync(AppUser user, string role)
		{
			return base.AddToRoleAsync(user, role);
		}

		public override Task<IdentityResult> AddToRolesAsync(AppUser user, IEnumerable<string> roles)
		{
			return base.AddToRolesAsync(user, roles);
		}

		public override Task<IdentityResult> ChangeEmailAsync(AppUser user, string newEmail, string token)
		{
			return base.ChangeEmailAsync(user, newEmail, token);
		}

		public override Task<IdentityResult> ChangePasswordAsync(AppUser user, string currentPassword, string newPassword)
		{
			return base.ChangePasswordAsync(user, currentPassword, newPassword);
		}

		public override Task<IdentityResult> ChangePhoneNumberAsync(AppUser user, string phoneNumber, string token)
		{
			return base.ChangePhoneNumberAsync(user, phoneNumber, token);
		}

		public override Task<bool> CheckPasswordAsync(AppUser user, string password)
		{
			return base.CheckPasswordAsync(user, password);
		}

		public override Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token)
		{
			return base.ConfirmEmailAsync(user, token);
		}

		public override Task<int> CountRecoveryCodesAsync(AppUser user)
		{
			return base.CountRecoveryCodesAsync(user);
		}

		public override Task<IdentityResult> CreateAsync(AppUser user)
		{
			return base.CreateAsync(user);
		}

		public override Task<IdentityResult> CreateAsync(AppUser user, string password)
		{
			return base.CreateAsync(user, password);
		}

		public override Task<byte[]> CreateSecurityTokenAsync(AppUser user)
		{
			return base.CreateSecurityTokenAsync(user);
		}

		public override Task<IdentityResult> DeleteAsync(AppUser user)
		{
			return base.DeleteAsync(user);
		}

		public override bool Equals(object? obj)
		{
			return base.Equals(obj);
		}

		public override Task<AppUser> FindByEmailAsync(string email)
		{
			return base.FindByEmailAsync(email);
		}

		public override Task<AppUser> FindByIdAsync(string userId)
		{
			return base.FindByIdAsync(userId);
		}

		public override Task<AppUser> FindByLoginAsync(string loginProvider, string providerKey)
		{
			return base.FindByLoginAsync(loginProvider, providerKey);
		}

		public override Task<AppUser> FindByNameAsync(string userName)
		{
			return base.FindByNameAsync(userName);
		}

		public override Task<string> GenerateChangeEmailTokenAsync(AppUser user, string newEmail)
		{
			return base.GenerateChangeEmailTokenAsync(user, newEmail);
		}

		public override Task<string> GenerateChangePhoneNumberTokenAsync(AppUser user, string phoneNumber)
		{
			return base.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);
		}

		public override Task<string> GenerateConcurrencyStampAsync(AppUser user)
		{
			return base.GenerateConcurrencyStampAsync(user);
		}

		public override Task<string> GenerateEmailConfirmationTokenAsync(AppUser user)
		{
			return base.GenerateEmailConfirmationTokenAsync(user);
		}

		public override string GenerateNewAuthenticatorKey()
		{
			return base.GenerateNewAuthenticatorKey();
		}

		public override Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(AppUser user, int number)
		{
			return base.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
		}

		public override Task<string> GeneratePasswordResetTokenAsync(AppUser user)
		{
			return base.GeneratePasswordResetTokenAsync(user);
		}

		public override Task<string> GenerateTwoFactorTokenAsync(AppUser user, string tokenProvider)
		{
			return base.GenerateTwoFactorTokenAsync(user, tokenProvider);
		}

		public override Task<string> GenerateUserTokenAsync(AppUser user, string tokenProvider, string purpose)
		{
			return base.GenerateUserTokenAsync(user, tokenProvider, purpose);
		}

		public override Task<int> GetAccessFailedCountAsync(AppUser user)
		{
			return base.GetAccessFailedCountAsync(user);
		}

		public override Task<string> GetAuthenticationTokenAsync(AppUser user, string loginProvider, string tokenName)
		{
			return base.GetAuthenticationTokenAsync(user, loginProvider, tokenName);
		}

		public override Task<string> GetAuthenticatorKeyAsync(AppUser user)
		{
			return base.GetAuthenticatorKeyAsync(user);
		}

		public override Task<IList<Claim>> GetClaimsAsync(AppUser user)
		{
			return base.GetClaimsAsync(user);
		}

		public override Task<string> GetEmailAsync(AppUser user)
		{
			return base.GetEmailAsync(user);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override Task<bool> GetLockoutEnabledAsync(AppUser user)
		{
			return base.GetLockoutEnabledAsync(user);
		}

		public override Task<DateTimeOffset?> GetLockoutEndDateAsync(AppUser user)
		{
			return base.GetLockoutEndDateAsync(user);
		}

		public override Task<IList<UserLoginInfo>> GetLoginsAsync(AppUser user)
		{
			return base.GetLoginsAsync(user);
		}

		public override Task<string> GetPhoneNumberAsync(AppUser user)
		{
			return base.GetPhoneNumberAsync(user);
		}

		public override Task<IList<string>> GetRolesAsync(AppUser user)
		{
			return base.GetRolesAsync(user);
		}

		public override Task<string> GetSecurityStampAsync(AppUser user)
		{
			return base.GetSecurityStampAsync(user);
		}

		public override Task<bool> GetTwoFactorEnabledAsync(AppUser user)
		{
			return base.GetTwoFactorEnabledAsync(user);
		}

		public override Task<AppUser> GetUserAsync(ClaimsPrincipal principal)
		{
			return base.GetUserAsync(principal);
		}

		public override string GetUserId(ClaimsPrincipal principal)
		{
			return base.GetUserId(principal);
		}

		public override Task<string> GetUserIdAsync(AppUser user)
		{
			return base.GetUserIdAsync(user);
		}

		public override string GetUserName(ClaimsPrincipal principal)
		{
			return base.GetUserName(principal);
		}

		public override Task<string> GetUserNameAsync(AppUser user)
		{
			return base.GetUserNameAsync(user);
		}

		public override Task<IList<AppUser>> GetUsersForClaimAsync(Claim claim)
		{
			return base.GetUsersForClaimAsync(claim);
		}

		public override Task<IList<AppUser>> GetUsersInRoleAsync(string roleName)
		{
			return base.GetUsersInRoleAsync(roleName);
		}

		public override Task<IList<string>> GetValidTwoFactorProvidersAsync(AppUser user)
		{
			return base.GetValidTwoFactorProvidersAsync(user);
		}

		public override Task<bool> HasPasswordAsync(AppUser user)
		{
			return base.HasPasswordAsync(user);
		}

		public override Task<bool> IsEmailConfirmedAsync(AppUser user)
		{
			return base.IsEmailConfirmedAsync(user);
		}

		public override Task<bool> IsInRoleAsync(AppUser user, string role)
		{
			return base.IsInRoleAsync(user, role);
		}

		public override Task<bool> IsLockedOutAsync(AppUser user)
		{
			return base.IsLockedOutAsync(user);
		}

		public override Task<bool> IsPhoneNumberConfirmedAsync(AppUser user)
		{
			return base.IsPhoneNumberConfirmedAsync(user);
		}

		public override string NormalizeEmail(string email)
		{
			return base.NormalizeEmail(email);
		}

		public override string NormalizeName(string name)
		{
			return base.NormalizeName(name);
		}

		public override Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(AppUser user, string code)
		{
			return base.RedeemTwoFactorRecoveryCodeAsync(user, code);
		}

		public override void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<AppUser> provider)
		{
			base.RegisterTokenProvider(providerName, provider);
		}

		public override Task<IdentityResult> RemoveAuthenticationTokenAsync(AppUser user, string loginProvider, string tokenName)
		{
			return base.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);
		}

		public override Task<IdentityResult> RemoveClaimAsync(AppUser user, Claim claim)
		{
			return base.RemoveClaimAsync(user, claim);
		}

		public override Task<IdentityResult> RemoveClaimsAsync(AppUser user, IEnumerable<Claim> claims)
		{
			return base.RemoveClaimsAsync(user, claims);
		}

		public override Task<IdentityResult> RemoveFromRoleAsync(AppUser user, string role)
		{
			return base.RemoveFromRoleAsync(user, role);
		}

		public override Task<IdentityResult> RemoveFromRolesAsync(AppUser user, IEnumerable<string> roles)
		{
			return base.RemoveFromRolesAsync(user, roles);
		}

		public override Task<IdentityResult> RemoveLoginAsync(AppUser user, string loginProvider, string providerKey)
		{
			return base.RemoveLoginAsync(user, loginProvider, providerKey);
		}

		public override Task<IdentityResult> RemovePasswordAsync(AppUser user)
		{
			return base.RemovePasswordAsync(user);
		}

		public override Task<IdentityResult> ReplaceClaimAsync(AppUser user, Claim claim, Claim newClaim)
		{
			return base.ReplaceClaimAsync(user, claim, newClaim);
		}

		public override Task<IdentityResult> ResetAccessFailedCountAsync(AppUser user)
		{
			return base.ResetAccessFailedCountAsync(user);
		}

		public override Task<IdentityResult> ResetAuthenticatorKeyAsync(AppUser user)
		{
			return base.ResetAuthenticatorKeyAsync(user);
		}

		public override Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword)
		{
			return base.ResetPasswordAsync(user, token, newPassword);
		}

		public override Task<IdentityResult> SetAuthenticationTokenAsync(AppUser user, string loginProvider, string tokenName, string tokenValue)
		{
			return base.SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);
		}

		public override Task<IdentityResult> SetEmailAsync(AppUser user, string email)
		{
			return base.SetEmailAsync(user, email);
		}

		public override Task<IdentityResult> SetLockoutEnabledAsync(AppUser user, bool enabled)
		{
			return base.SetLockoutEnabledAsync(user, enabled);
		}

		public override Task<IdentityResult> SetLockoutEndDateAsync(AppUser user, DateTimeOffset? lockoutEnd)
		{
			return base.SetLockoutEndDateAsync(user, lockoutEnd);
		}

		public override Task<IdentityResult> SetPhoneNumberAsync(AppUser user, string phoneNumber)
		{
			return base.SetPhoneNumberAsync(user, phoneNumber);
		}

		public override Task<IdentityResult> SetTwoFactorEnabledAsync(AppUser user, bool enabled)
		{
			return base.SetTwoFactorEnabledAsync(user, enabled);
		}

		public override Task<IdentityResult> SetUserNameAsync(AppUser user, string userName)
		{
			return base.SetUserNameAsync(user, userName);
		}

		public override string? ToString()
		{
			return base.ToString();
		}

		public override Task<IdentityResult> UpdateAsync(AppUser user)
		{
			return base.UpdateAsync(user);
		}

		public override Task UpdateNormalizedEmailAsync(AppUser user)
		{
			return base.UpdateNormalizedEmailAsync(user);
		}

		public override Task UpdateNormalizedUserNameAsync(AppUser user)
		{
			return base.UpdateNormalizedUserNameAsync(user);
		}

		public override Task<IdentityResult> UpdateSecurityStampAsync(AppUser user)
		{
			return base.UpdateSecurityStampAsync(user);
		}

		public override Task<bool> VerifyChangePhoneNumberTokenAsync(AppUser user, string token, string phoneNumber)
		{
			return base.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);
		}

		public override Task<bool> VerifyTwoFactorTokenAsync(AppUser user, string tokenProvider, string token)
		{
			return base.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
		}

		public override Task<bool> VerifyUserTokenAsync(AppUser user, string tokenProvider, string purpose, string token)
		{
			return base.VerifyUserTokenAsync(user, tokenProvider, purpose, token);
		}

		protected override string CreateTwoFactorRecoveryCode()
		{
			return base.CreateTwoFactorRecoveryCode();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		protected override Task<IdentityResult> UpdatePasswordHash(AppUser user, string newPassword, bool validatePassword)
		{
			return base.UpdatePasswordHash(user, newPassword, validatePassword);
		}

		protected override Task<IdentityResult> UpdateUserAsync(AppUser user)
		{
			return base.UpdateUserAsync(user);
		}

		protected override Task<PasswordVerificationResult> VerifyPasswordAsync(IUserPasswordStore<AppUser> store, AppUser user, string password)
		{
			return base.VerifyPasswordAsync(store, user, password);
		}
	}
}
