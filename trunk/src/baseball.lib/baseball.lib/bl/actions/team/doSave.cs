using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.team
{
    public class doSave : core.ActionBL<model.Team>
    {
        private model.Team _team = null;
        public doSave(model.Team team)
        {
            _team = team;
        }
        
        protected override model.Team action()
        {
            try
            {
                //core.Check.Team(this, _team, Cache);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Team temp = db.Teams.Where(o => o.Id == _team.Id).SingleOrDefault();
                    if (temp == null)
                    {
                        _team.Active = true;
                        db.Teams.InsertOnSubmit(_team);
                    }
                    else
                    {
                        temp.Name = _team.Name;
                        temp.ClubId = _team.ClubId;
                    }

                    db.SubmitChanges();
                }

                return _team;
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
