using CampusMindEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusMind.Models
{
    public class ConvertModelToEntity : IConvertModelToEntity
    {
        public TechnologyEntity ConvertTechnologyToEntity(Technology technology)
        {
            TechnologyEntity technologyEntity = new TechnologyEntity();
            technologyEntity.TechnolgyId = technology.TechnolgyId;
            technologyEntity.TechnologyName = technology.TechnologyName;

            return technologyEntity;
        }
        public UserEntity ConvertAccessToEntity(User user)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.UserName = user.UserName;
            userEntity.Password = user.Password;
            userEntity.RoleAssign = user.RoleAssign;

            return userEntity;
        }

        public LeadEntity ConvertLeadToEntity(Lead lead)
        {
            LeadEntity leadEntity = new LeadEntity();
            leadEntity.LeadId = lead.LeadId;
            leadEntity.LeadName = lead.LeadName;
            leadEntity.TechnologyId = lead.technologyId;

            return leadEntity;
        }

        public CandidateEntity ConvertCandidateToEntity(Candidate candidate)
        {
            CandidateEntity candidateEntity = new CandidateEntity();
            candidateEntity.CandidateId = candidate.CandidateId;
            candidateEntity.CandidateName = candidate.CandidateName;
            candidateEntity.LeadId = candidate.LeadId;

            return candidateEntity;
        }
    }
}
