using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.license
{
    public class doGetAll : core.ActionBL<List<model.License>>
    {
        public doGetAll()
        {
        }

        protected override List<model.License> action()
        {
            try
            {
                List<model.License> res = new List<model.License>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Licenses.OrderBy(o => o.ToString()).ToList<model.License>();
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
