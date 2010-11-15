using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.stadium
{
    internal class doDelete : core.ActionBL
    {
        private model.Stadium _stadium = null;
        public doDelete(model.Stadium stadium)
        {
            _stadium = stadium;
        }


        public new model.Stadium execute(ICache cache)
        {
            return (model.Stadium)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                core.Check.Stadium(this, _stadium);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Stadium temp = db.Stadiums.SingleOrDefault(o => o.Id == _stadium.Id);
                    if (temp != null)
                    {
                        db.Stadiums.DeleteOnSubmit(temp);
                        db.SubmitChanges();
                    }
                }

                return _stadium;
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
