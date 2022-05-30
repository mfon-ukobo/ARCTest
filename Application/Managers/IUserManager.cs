﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Managers
{
	public interface IUserManager
	{
		ILogger Logger { get; set; }
		bool SupportsUserAuthenticationTokens { get; }
		bool SupportsUserAuthenticatorKey { get; }
		bool SupportsUserTwoFactorRecoveryCodes { get; }
		bool SupportsUserTwoFactor { get; }
		bool SupportsUserPassword { get; }
		bool SupportsUserSecurityStamp { get; }
		bool SupportsUserRole { get; }
		bool SupportsUserLogin { get; }
		bool SupportsUserEmail { get; }
		bool SupportsUserPhoneNumber { get; }
		bool SupportsUserClaim { get; }
		bool SupportsUserLockout { get; }
		bool SupportsQueryableUsers { get; }
		IQueryable<AppUser> Users { get; }

		Task<IdentityResult> AccessFailedAsync(AppUser user);
		Task<IdentityResult> AddClaimAsync(AppUser user, Claim claim);
		Task<IdentityResult> AddClaimsAsync(AppUser user, IEnumerable<Claim> claims);
		Task<IdentityResult> AddLoginAsync(AppUser user, UserLoginInfo login);
		Task<IdentityResult> AddPasswordAsync(AppUser user, string password);
		Task<IdentityResult> AddToRoleAsync(AppUser user, string role);
		Task<IdentityResult> AddToRolesAsync(AppUser user, IEnumerable<string> roles);
		Task<IdentityResult> ChangeEmailAsync(AppUser user, string newEmail, string token);
		Task<IdentityResult> ChangePasswordAsync(AppUser user, string currentPassword, string newPassword);
		Task<IdentityResult> ChangePhoneNumberAsync(AppUser user, string phoneNumber, string token);
		Task<bool> CheckPasswordAsync(AppUser user, string password);
		Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token);
		Task<int> CountRecoveryCodesAsync(AppUser user);
		Task<IdentityResult> CreateAsync(AppUser user);
		Task<IdentityResult> CreateAsync(AppUser user, string password);
		Task<byte[]> CreateSecurityTokenAsync(AppUser user);
		Task<IdentityResult> DeleteAsync(AppUser user);
		bool Equals(object? obj);
		Task<AppUser> FindByEmailAsync(string email);
		Task<AppUser> FindByIdAsync(string userId);
		Task<AppUser> FindByLoginAsync(string loginProvider, string providerKey);
		Task<AppUser> FindByNameAsync(string userName);
		Task<string> GenerateChangeEmailTokenAsync(AppUser user, string newEmail);
		Task<string> GenerateChangePhoneNumberTokenAsync(AppUser user, string phoneNumber);
		Task<string> GenerateConcurrencyStampAsync(AppUser user);
		Task<string> GenerateEmailConfirmationTokenAsync(AppUser user);
		string GenerateNewAuthenticatorKey();
		Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(AppUser user, int number);
		Task<string> GeneratePasswordResetTokenAsync(AppUser user);
		Task<string> GenerateTwoFactorTokenAsync(AppUser user, string tokenProvider);
		Task<string> GenerateUserTokenAsync(AppUser user, string tokenProvider, string purpose);
		Task<int> GetAccessFailedCountAsync(AppUser user);
		Task<string> GetAuthenticationTokenAsync(AppUser user, string loginProvider, string tokenName);
		Task<string> GetAuthenticatorKeyAsync(AppUser user);
		Task<IList<Claim>> GetClaimsAsync(AppUser user);
		Task<string> GetEmailAsync(AppUser user);
		int GetHashCode();
		Task<bool> GetLockoutEnabledAsync(AppUser user);
		Task<DateTimeOffset?> GetLockoutEndDateAsync(AppUser user);
		Task<IList<UserLoginInfo>> GetLoginsAsync(AppUser user);
		Task<string> GetPhoneNumberAsync(AppUser user);
		Task<IList<string>> GetRolesAsync(AppUser user);
		Task<string> GetSecurityStampAsync(AppUser user);
		Task<bool> GetTwoFactorEnabledAsync(AppUser user);
		Task<AppUser> GetUserAsync(ClaimsPrincipal principal);
		string GetUserId(ClaimsPrincipal principal);
		Task<string> GetUserIdAsync(AppUser user);
		string GetUserName(ClaimsPrincipal principal);
		Task<string> GetUserNameAsync(AppUser user);
		Task<IList<AppUser>> GetUsersForClaimAsync(Claim claim);
		Task<IList<AppUser>> GetUsersInRoleAsync(string roleName);
		Task<IList<string>> GetValidTwoFactorProvidersAsync(AppUser user);
		Task<bool> HasPasswordAsync(AppUser user);
		Task<bool> IsEmailConfirmedAsync(AppUser user);
		Task<bool> IsInRoleAsync(AppUser user, string role);
		Task<bool> IsLockedOutAsync(AppUser user);
		Task<bool> IsPhoneNumberConfirmedAsync(AppUser user);
		string NormalizeEmail(string email);
		string NormalizeName(string name);
		Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(AppUser user, string code);
		void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<AppUser> provider);
		Task<IdentityResult> RemoveAuthenticationTokenAsync(AppUser user, string loginProvider, string tokenName);
		Task<IdentityResult> RemoveClaimAsync(AppUser user, Claim claim);
		Task<IdentityResult> RemoveClaimsAsync(AppUser user, IEnumerable<Claim> claims);
		Task<IdentityResult> RemoveFromRoleAsync(AppUser user, string role);
		Task<IdentityResult> RemoveFromRolesAsync(AppUser user, IEnumerable<string> roles);
		Task<IdentityResult> RemoveLoginAsync(AppUser user, string loginProvider, string providerKey);
		Task<IdentityResult> RemovePasswordAsync(AppUser user);
		Task<IdentityResult> ReplaceClaimAsync(AppUser user, Claim claim, Claim newClaim);
		Task<IdentityResult> ResetAccessFailedCountAsync(AppUser user);
		Task<IdentityResult> ResetAuthenticatorKeyAsync(AppUser user);
		Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword);
		Task<IdentityResult> SetAuthenticationTokenAsync(AppUser user, string loginProvider, string tokenName, string tokenValue);
		Task<IdentityResult> SetEmailAsync(AppUser user, string email);
		Task<IdentityResult> SetLockoutEnabledAsync(AppUser user, bool enabled);
		Task<IdentityResult> SetLockoutEndDateAsync(AppUser user, DateTimeOffset? lockoutEnd);
		Task<IdentityResult> SetPhoneNumberAsync(AppUser user, string phoneNumber);
		Task<IdentityResult> SetTwoFactorEnabledAsync(AppUser user, bool enabled);
		Task<IdentityResult> SetUserNameAsync(AppUser user, string userName);
		string? ToString();
		Task<IdentityResult> UpdateAsync(AppUser user);
		Task UpdateNormalizedEmailAsync(AppUser user);
		Task UpdateNormalizedUserNameAsync(AppUser user);
		Task<IdentityResult> UpdateSecurityStampAsync(AppUser user);
		Task<bool> VerifyChangePhoneNumberTokenAsync(AppUser user, string token, string phoneNumber);
		Task<bool> VerifyTwoFactorTokenAsync(AppUser user, string tokenProvider, string token);
		Task<bool> VerifyUserTokenAsync(AppUser user, string tokenProvider, string purpose, string token);
	}
}
