using AssayDatabaseAPI.DTOs;
using AssayDatabaseAPI.Models;
using AutoMapper;

namespace AssayDatabaseAPI.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>();
        CreateMap<Assay, AssayDto>();
    }
}