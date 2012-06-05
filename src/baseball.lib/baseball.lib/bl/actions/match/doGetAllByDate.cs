using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.match
{
    public class doGetAllByDate : core.ActionBL<List<model.Match>>
    {
        private DateTime _date;
        public doGetAllByDate(DateTime date)
        {
            _date = date;
        }

        protected override List<model.Match> action()
        {
            try
            {
                List<model.Match> res = new List<model.Match>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Matches.Where(o => o.Date.Date == _date.Date).OrderBy(o => o.Date).ToList<model.Match>();
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
