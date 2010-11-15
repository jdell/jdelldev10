using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.club
{
    public class doDelete : core.ActionBL
    {
        private model.Club _club = null;
        public doDelete(model.Club club)
        {
            _club = club;
        }


        public new model.Club execute(ICache cache)
        {
            return (model.Club)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                core.Check.Club(this, _club);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Club temp = db.Clubs.SingleOrDefault(o => o.Id == _club.Id);
                    if (temp != null)
                    {
                        //db.Clubs.DeleteOnSubmit(temp);
                        temp.Active = false;
                        db.SubmitChanges();
                    }
                }

                return _club;
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
