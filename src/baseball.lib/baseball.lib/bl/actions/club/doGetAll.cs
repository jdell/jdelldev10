﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.club
{
    public class doGetAll : core.ActionBL<List<model.Club>>
    {
        public doGetAll()
        {
        }

        protected override List<model.Club> action()
        {
            try
            {
                List<model.Club> res = new List<model.Club>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Clubs.Where(o => o.Active).OrderBy(o => o.Name).ToList<model.Club>();
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
