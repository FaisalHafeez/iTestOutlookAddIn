using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bootstrap.AutoMapper;
using AutoMapper;
using HunterCV.Model;

namespace HunterCV.FrontSite.AutoMapper
{
    public class MappingCreator : IMapCreator
    {
        public void CreateMap(IProfileExpression mapper)
        {
            mapper.CreateMap<Candidate, HunterCV.Common.Candidate>()
                      .ForMember(dest => dest.Username, opt => opt.ResolveUsing<CandidateUserResolver>());
                      //.ForMember(dest => dest.IsFavorite, opt => opt.ResolveUsing<FavoritesUserResolver>());

            mapper.CreateMap<HunterCV.Common.Candidate, Candidate>()
                .ForMember(dest => dest.CandidatePositions, opt =>
                {
                    opt.UseDestinationValue();
                    opt.Ignore();
                })
                .ForMember(dest => dest.FavoriteUsers, opt => opt.Ignore());

            mapper.CreateMap<Position, HunterCV.Common.Position>()
                .ForMember(dest => dest.Username, opt => opt.ResolveUsing<PositionUserResolver>()).ReverseMap();

            mapper.CreateMap<CandidatePosition, HunterCV.Common.CandidatePosition>();

            mapper.CreateMap<HunterCV.Common.CandidatePosition, CandidatePosition>();

            mapper.CreateMap<Resume, HunterCV.Common.Resume>().ReverseMap();
            mapper.CreateMap<Preview, HunterCV.Common.Preview>().ReverseMap();
            mapper.CreateMap<MailTemplate, HunterCV.Common.MailTemplate>().ReverseMap();
        }
    }
}