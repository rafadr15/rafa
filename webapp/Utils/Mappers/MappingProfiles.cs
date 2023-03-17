using AutoMapper;
using webapp.Features.Assignments.Models;
using webapp.Features.Assignments.Views;

namespace webapp.Utils.Mappers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AssignmentModel, AssignmentRequest>().ReverseMap();
        CreateMap<AssignmentModel, AssignmentResponse>().ReverseMap();
        
        
    }
}