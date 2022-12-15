﻿using System.Security.Cryptography;
using System.Text;
using AssayDatabaseAPI.Data;
using AssayDatabaseAPI.DTOs;
using AssayDatabaseAPI.Interfaces;
using AssayDatabaseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssayDatabaseAPI.Controllers;

public class AccountController : BaseApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Email)) return BadRequest("Email is taken, do you already have an account?");
        
        using var hmac = new HMACSHA512();
        var user = new AppUser
        {
            Email = registerDto.Email.ToLower(),
            UserName = registerDto.Username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
        if (user == null) return Unauthorized();
        
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
        }

        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        };
    }

    private async Task<bool> UserExists(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email.ToLower());
    }

}