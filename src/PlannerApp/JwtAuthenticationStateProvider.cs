using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _storage;

    public JwtAuthenticationStateProvider(ILocalStorageService storage)
    {
        _storage=storage;
    }
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {

        //To Bypass authenticatiom, specify a dummay claim using below line of code
        //  return new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim("Id", "123") }, "Bearer")));

        if (await _storage.ContainKeyAsync("access_token"))//sds..
        {
            //user is logged in, hence decode the token and get claims
            var tokenAsString = await _storage.GetItemAsStringAsync("access_token");
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenAsString);
            var identity = new ClaimsIdentity(token.Claims,"Bearer");
            var user = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));//notifies components if user logged in
            return authState;
        }
        return new AuthenticationState(new ClaimsPrincipal());//Empty Claim prinicipal means no identity and user is not logged in
        }
}
