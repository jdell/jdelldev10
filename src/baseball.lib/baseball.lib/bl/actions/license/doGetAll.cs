using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.license
{
    public class doGetAll : core.ActionBL
    {
        public doGetAll()
        {
        }


        public new List<model.License> execute(ICache cache)
        {
            return (List<model.License>)base.execute(cache);
        }

        protected override object action()
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
