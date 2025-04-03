using Application.Dtos.AuthDto;
using Microsoft.AspNetCore.Identity.Data;

namespace Application.Auth.Queries;

public record LoginUserQuery(LoginRequest dto) : IQuery<LoginUserResult>;

public record LoginUserResult(IdentityUserResponceDto Identity);