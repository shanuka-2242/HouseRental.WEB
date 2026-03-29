using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HouseRental.WASB.Utilities
{
    public static class CustomFunctions
    {
        public static void WriteConsoleLog(string errorLevel, string logLine)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy/MM/dd HH:mm:ss}] [{errorLevel}]> {logLine}");
        }

        public static string GenerateUniqueId(string input)
        {
            string SHAstring = string.Empty;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                SHAstring = builder.ToString();
            }
            return SHAstring;
        }
    }

    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        private ClaimsPrincipal _currentUser;

        public CustomAuthStateProvider()
        {
            _currentUser = _anonymous;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser));
        }

        public void NotifyUserLogin(string email)
        {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth");
            _currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }

        public void NotifyUserLogout()
        {
            _currentUser = _anonymous;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }
}
