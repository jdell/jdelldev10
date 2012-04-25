using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.match
{
    public class doGet : core.ActionBL
    {
        private Guid _id;
        public doGet(Guid id)
        {
            _id = id;
        }


        public new model.Match execute(ICache cache)
        {
            return (model.Match)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                model.Match res = new model.Match();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Matches.Where(o => o.Id == _id).SingleOrDefault();
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
