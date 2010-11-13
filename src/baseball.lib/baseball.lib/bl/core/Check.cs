using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;

namespace com.mxply.app.baseball.lib.bl.core
{
    internal abstract class Check
    {
        internal static void Federation(ActionBL action, model.Federation obj)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.Federation), action.GetType().Name);

        }
        internal static void ChampionshipType(ActionBL action, model.ChampionshipType obj)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.ChampionshipType), action.GetType().Name);

        }
        internal static void Club(ActionBL action, model.Club obj)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.Club), action.GetType().Name);

            //if (obj.FederationId == Guid.Empty)

        }
        internal static void Team(ActionBL action, model.Team obj)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.Team), action.GetType().Name);

            //if (obj.FederationId == Guid.Empty)

        }
        internal static void Person(ActionBL action, model.Person obj)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.Person), action.GetType().Name);

            //if (obj.FederationId == Guid.Empty)

        }
    }
}
