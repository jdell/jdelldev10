﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.team
{
    public class doDelete : core.ActionBL< model.Team>
    {
        private model.Team _team = null;
        public doDelete(model.Team team)
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
                    model.Team temp = db.Teams.SingleOrDefault(o => o.Id == _team.Id);
                    if (temp != null)
                    {
                        //db.Teams.DeleteOnSubmit(temp);
                        temp.Active = false;
                        db.SubmitChanges();
                    }
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
