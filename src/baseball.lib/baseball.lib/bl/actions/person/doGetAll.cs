using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.person
{
    public class doGetAll : core.ActionBL<List<model.Person>>
    {
        public doGetAll()
        {
        }


        protected override List<model.Person> action()
        {
            try
            {
                List<model.Person> res = new List<model.Person>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.Persons.Where(o => o.Active).OrderBy(o => o.ToString()).ToList<model.Person>();
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
