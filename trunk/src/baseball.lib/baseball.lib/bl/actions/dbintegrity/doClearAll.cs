using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.dbintegrity
{
    internal class doClearAll : core.ActionBL
    {
        public new bool execute(ICache cache)
        {
            return (bool)base.execute(cache);
        }

        protected override object action()
        {
            try
            {

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    db.Matches.DeleteAllOnSubmit(db.Matches);
                    db.ChampionshipOrganizers.DeleteAllOnSubmit(db.ChampionshipOrganizers);
                    db.ChampionshipTeams.DeleteAllOnSubmit(db.ChampionshipTeams);
                    db.Championships.DeleteAllOnSubmit(db.Championships);
                    db.Stadiums.DeleteAllOnSubmit(db.Stadiums);
                    db.LicenseCounters.DeleteAllOnSubmit(db.LicenseCounters);
                    db.Licenses.DeleteAllOnSubmit(db.Licenses);
                    db.Persons.DeleteAllOnSubmit(db.Persons);
                    db.Teams.DeleteAllOnSubmit(db.Teams);
                    db.Clubs.DeleteAllOnSubmit(db.Clubs);
                    db.Federations.DeleteAllOnSubmit(db.Federations);

                    db.SubmitChanges();
                }
                return true;
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
