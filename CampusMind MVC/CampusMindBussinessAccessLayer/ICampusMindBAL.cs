using CampusMindEntity;

namespace CampusMindBussinessAccessLayer
{
    public interface ICampusMindBAL
    {
        void AddAccess(UserEntity accessEntity);
        void AddCandidate(CandidateEntity candidateEntity);
        void AddLead(LeadEntity leadEntity);
        void AddTechnology(TechnologyEntity technologyEntity);
        void DeleteCandidate(CandidateEntity candidateEntity);
        void DeleteLead(LeadEntity leadEntity);
        void DeleteTechnology(TechnologyEntity technologyEntity);
        void ShowCandidate(CandidateEntity candidateEntity);
        void ShowLead(LeadEntity leadEntity);
        void ShowTechnology(TechnologyEntity technologyEntity);
        void UpdateCandidate(CandidateEntity candidateEntity);
        void UpdateLead(LeadEntity leadEntity);
    }
}