using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.federation
{
    public class doGetAll : core.ActionBL
    {
        public doGetAll()
        {
        }


        public new List<model.Federation> execute(BaseCache cache)
        {
            return (List<model.Federation>)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                List<model.Federation> res = new List<model.Federation>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Federations.Where(o => o.Active).OrderBy(o => o.Name).ToList<model.Federation>();
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
