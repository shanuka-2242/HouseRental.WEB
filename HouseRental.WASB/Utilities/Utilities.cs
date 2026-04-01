using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
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

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var authenticationState = new AuthenticationState(new ClaimsPrincipal());
                var useremail = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "useremail");
                if (!string.IsNullOrWhiteSpace(useremail))
                {
                    var identity = new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.Name, useremail)
                    ], "apiauth");

                    authenticationState = new AuthenticationState(new ClaimsPrincipal(identity));
                }
                NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
                return authenticationState;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
