﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.matchstatus
{
    public class doGetAll : core.ActionBL
    {
        public doGetAll()
        {
        }


        public new List<model.MatchStatus> execute(ICache cache)
        {
            return (List<model.MatchStatus>)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                List<model.MatchStatus> res = new List<model.MatchStatus>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.MatchStatus.OrderBy(o => o.Description).ToList<model.MatchStatus>();
                }

                return res;
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
