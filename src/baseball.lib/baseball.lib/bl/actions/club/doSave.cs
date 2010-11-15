using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.club
{
    public class doSave : core.ActionBL
    {
        private model.Club _club = null;
        public doSave(model.Club club)
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
                    model.Club temp = db.Clubs.Where(o => o.Id == _club.Id).SingleOrDefault();
                    if (temp == null)
                    {
                        _club.Active = true;
                        db.Clubs.InsertOnSubmit(_club);
                    }
                    else
                    {
                        temp.Name = _club.Name;
                        temp.Address = _club.Address;
                    }

                    db.SubmitChanges();
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
