using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.movementtype
{
    public class doGetAll : core.ActionBL
    {
        public doGetAll()
        {
        }


        public new List<model.MovementType> execute(BaseCache cache)
        {
            return (List<model.MovementType>)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                List<model.MovementType> res = new List<model.MovementType>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.MovementTypes.OrderBy(o => o.Description).ToList<model.MovementType>();
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
