using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;
using com.mxply.app.baseball.lib.model;

namespace com.mxply.app.baseball.lib.bl.actions.match
{
    public class doGet : core.ActionBL<Match>
    {
        private Guid _id;
        public doGet(Guid id)
        {
            _id = id;
        }

        
        protected override Match action()
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
