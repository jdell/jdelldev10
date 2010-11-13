using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.team
{
    public class doSave : core.ActionBL
    {
        private model.Team _team = null;
        public doSave(model.Team team)
        {
            _team = team;
        }

        public new model.Team execute(BaseCache cache)
        {
            return (model.Team)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                core.Check.Team(this, _team);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Team temp = db.Teams.Where(o => o.Id == _team.Id).SingleOrDefault();
                    if (temp == null)
                        db.Teams.InsertOnSubmit(_team);
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
