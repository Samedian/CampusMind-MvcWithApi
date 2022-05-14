using CampusMindEntity;

namespace CampusMind.Models
{
    public interface IConvertModelToEntity
    {
        UserEntity ConvertAccessToEntity(User user);
        LeadEntity ConvertLeadToEntity(Lead lead);
        TechnologyEntity ConvertTechnologyToEntity(Technology technology);
        CandidateEntity ConvertCandidateToEntity(Candidate candidate);
    }
}