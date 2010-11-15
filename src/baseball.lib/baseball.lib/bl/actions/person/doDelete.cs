using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.person
{
    internal class doDelete : core.ActionBL
    {
        private model.Person _person = null;
        public doDelete(model.Person person)
        {
            _person = person;
        }


        public new model.Person execute(ICache cache)
        {
            return (model.Person)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                core.Check.Person(this, _person);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Person temp = db.Persons.SingleOrDefault(o => o.Id == _person.Id);
                    if (temp != null)
                    {
                        //db.Persons.DeleteOnSubmit(temp);
                        temp.Active = false;
                        db.SubmitChanges();
                    }
                }

                return _person;
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
