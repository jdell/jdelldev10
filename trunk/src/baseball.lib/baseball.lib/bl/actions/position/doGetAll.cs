using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.position
{
    public class doGetAll : core.ActionBL<List<model.Position>>
    {
        public doGetAll()
        {
        }

        protected override List<model.Position> action()
        {
            try
            {
                List<model.Position> res = new List<model.Position>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Positions.OrderBy(o => o.Description).ToList<model.Position>();
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
