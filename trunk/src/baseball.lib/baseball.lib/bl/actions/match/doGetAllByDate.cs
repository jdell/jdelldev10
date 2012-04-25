using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.match
{
    public class doGetAllByDate : core.ActionBL
    {
        private DateTime _date;
        public doGetAllByDate(DateTime date)
        {
            _date = date;
        }


        public new List<model.Match> execute(ICache cache)
        {
            return (List<model.Match>)base.execute(cache);
        }

        protected override object action()
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
