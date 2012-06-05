using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.stadium
{
    public class doGetAll : core.ActionBL<List<model.Stadium>>
    {
        public doGetAll()
        {
        }

        protected override List<model.Stadium> action()
        {
            try
            {
                List<model.Stadium> res = new List<model.Stadium>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Stadiums.OrderBy(o => o.Name).ToList<model.Stadium>();
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
