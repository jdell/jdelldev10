using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.championship
{
    public class doDelete : core.ActionBL<model.Championship>
    {
        private model.Championship _championship = null;
        public doDelete(model.Championship championship)
        {
            _championship = championship;
        }

        protected override model.Championship action()
        {
            try
            {
                //core.Check.Championship(this, _championship);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Championship temp = db.Championships.SingleOrDefault(o => o.Id == _championship.Id);
                    if (temp != null)
                    {
                        //db.Championships.DeleteOnSubmit(temp);
                        temp.Active = false;
                        db.SubmitChanges();
                    }
                }

                return _championship;
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
