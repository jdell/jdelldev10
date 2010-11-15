using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

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
        internal static void Team(ActionBL action, model.Team obj, ICache cache)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.Team), action.GetType().Name);

            if (((core.Cache)cache).IsEmpty(obj.Id))
                throw new Mxply.Exceptions.MissingIdException(typeof(model.Team), action.GetType().Name);

            //if (obj.FederationId == Guid.Empty)

        }
        internal static void Person(ActionBL action, model.Person obj)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.Person), action.GetType().Name);

            //if (obj.FederationId == Guid.Empty)

        }
        internal static void License(ActionBL action, model.License obj)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.License), action.GetType().Name);

            //if (obj.FederationId == Guid.Empty)

        }
        internal static void Stadium(ActionBL action, model.Stadium obj)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.Stadium), action.GetType().Name);

            //if (obj.FederationId == Guid.Empty)

        }
        internal static void Championship(ActionBL action, model.Championship obj)
        {
            if (obj == null)
                throw new Mxply.Exceptions.NullReferenceException(typeof(model.Championship), action.GetType().Name);

            //if (obj.FederationId == Guid.Empty)

        }
    }
}
