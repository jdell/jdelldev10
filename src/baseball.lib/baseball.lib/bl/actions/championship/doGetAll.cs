using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.championship
{
    public class doGetAll : core.ActionBL<List<model.Championship>>
    {
        public doGetAll()
        {
        }

        protected override List<model.Championship> action()
        {
            try
            {
                List<model.Championship> res = new List<model.Championship>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Championships.Where(o => o.Active).OrderBy(o => o.ToString()).ToList<model.Championship>();
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
