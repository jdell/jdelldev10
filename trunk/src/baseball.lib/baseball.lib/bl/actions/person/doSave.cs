using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.person
{
    internal class doSave : core.ActionBL<model.Person>
    {
        private model.Person _person = null;
        public doSave(model.Person person)
        {
            _person = person;
        }

        protected override model.Person action()
        {
            try
            {
                //core.Check.Person(this, _person);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Person temp = db.Persons.Where(o => o.Id == _person.Id).SingleOrDefault();
                    if (temp == null)
                    {
                        _person.Active = true;
                        db.Persons.InsertOnSubmit(_person);
                    }
                    else
                    {
                        temp.FirstName = _person.FirstName;
                        temp.LastName = _person.LastName;
                        temp.Active = _person.Active;
                    }

                    db.SubmitChanges();
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
