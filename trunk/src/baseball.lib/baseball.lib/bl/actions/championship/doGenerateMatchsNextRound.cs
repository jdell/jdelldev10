using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.championship
{
    public class doGenerateMatchsNextRound : core.ActionBL
    {
        private model.Championship _championship = null;
        DateTime _firstMatchDate;
        public doGenerateMatchsNextRound(model.Championship championship, DateTime firstMatchDate)
        {
            _championship = championship;
            _firstMatchDate = firstMatchDate;
        }

        public new List<model.Match> execute(ICache cache)
        {
            return (List<model.Match>)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                core.Check.Championship(this, _championship);

                //TODO: Championship - NextRound
                //League - Playoffs
                //Tournament - Next Lap
                throw new NotImplementedException();

                //List<model.Match> Matches = null;

                //using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                //{
                //    _championship = db.Championships.Where(o => o.Id == _championship.Id).SingleOrDefault();
                //    if (_championship == null) return null;

                //    List<model.ChampionshipTeam> ChampionshipTeams = db.ChampionshipTeams.Where(o => o.ChampionshipId == _championship.Id).ToList();
                //    if (ChampionshipTeams == null || ChampionshipTeams.Count == 0) return null;
                    
                //    //var query = from p in db.Persons
                //    //            from l in db.Licenses
                //    //            where p.Active && p.Id == l.PersonId && common.enums.LicenseType.Umpire == model.LicenseType.Convert(l.LicenseType.InternalId)
                //    //            select p;
                //    List<model.Stadium> Stadiums = db.Stadiums.ToList();
                //    if (Stadiums == null || Stadiums.Count == 0) return null;
                  

                //    List<model.Person> Umpires = db.Persons.Join(db.Licenses, person => person.Id, license => license.PersonId, (person , license) => new {person, license.LicenseType}).Where( j => j.LicenseType.InternalId == model.LicenseType.Convert(common.enums.LicenseType.Umpire)).Select(o => o.person).ToList();
                //    if (Umpires == null || Umpires.Count == 0) return null;
                  
                //    List<model.Person> ScoreTakers = db.Persons.Join(db.Licenses, person => person.Id, license => license.PersonId, (person , license) => new {person, license.LicenseType}).Where( j => j.LicenseType.InternalId == model.LicenseType.Convert(common.enums.LicenseType.ScoreTaker)).Select(o => o.person).ToList();

                //    model.MatchStatus defaultMatchStatus = db.MatchStatus.Where(o => o.InternalId == model.MatchStatus.Convert(common.enums.MatchStatus.Pending)).FirstOrDefault();
                //    if (defaultMatchStatus == null) return null;

                //    Matches = new List<model.Match>();
                //    switch (model.ChampionshipType.Convert(_championship.ChampionshipType.InternalId))
                //    {
                //        case com.mxply.app.baseball.lib.common.enums.ChampionshipType.League:
                //            for (int i = 0; i < ChampionshipTeams.Count; i++)
                //            {
                //                //TODO: Calc the Date + Number of stadiums + matchs per day
                //                DateTime matchDate = _firstMatchDate;
                //                for (int j = i+1; j < ChampionshipTeams.Count; j++)
                //                {
                //                    model.Match match = null;

                //                    // 2 Matches per round
                //                    match = new model.Match();
                //                    match.Id = ((core.Cache)Cache).GetNewId();
                //                    match.HomeClubId = ChampionshipTeams[i].TeamId;
                //                    match.GuestClubId = ChampionshipTeams[j].TeamId;
                //                    match.Date = matchDate;
                //                    match.Umpire1Id = Umpires[0].Id;
                //                    match.StadiumId = Stadiums[0].Id;
                //                    match.MatchStatusId = defaultMatchStatus.Id;
                //                    Matches.Add(match);

                //                    match = new model.Match();
                //                    match.Id = ((core.Cache)Cache).GetNewId();
                //                    match.HomeClubId = ChampionshipTeams[j].TeamId;
                //                    match.GuestClubId = ChampionshipTeams[i].TeamId;
                //                    //TODO: Calc the Date
                //                    match.Date = matchDate.AddDays(7 * ChampionshipTeams.Count-1); ;
                //                    match.Umpire1Id = Umpires[0].Id;
                //                    match.StadiumId = Stadiums[0].Id;
                //                    match.MatchStatusId = defaultMatchStatus.Id;
                //                    Matches.Add(match);

                //                    matchDate = matchDate.AddDays(7);
                //                }
                //            }
                //            break;
                //        case com.mxply.app.baseball.lib.common.enums.ChampionshipType.Tournament:
                //            //TODO: Complete - Tournament
                //            break;
                //        default:
                //            return false;
                //    }
                //    if (Matches != null && Matches.Count>0)
                //    {
                //        db.Matches.InsertAllOnSubmit(Matches);
                //        db.SubmitChanges();
                //    }
                //}

                //return Matches;
            }
            catch (exceptions.BaseballException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
