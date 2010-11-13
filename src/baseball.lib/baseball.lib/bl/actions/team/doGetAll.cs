using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.team
{
    public class doGetAll : core.ActionBL
    {
        public doGetAll()
        {
        }


        public new List<model.Team> execute(BaseCache cache)
        {
            return (List<model.Team>)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                List<model.Team> res = new List<model.Team>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Teams.Where(o => o.Active).OrderBy(o => o.Name).ToList<model.Team>();
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
