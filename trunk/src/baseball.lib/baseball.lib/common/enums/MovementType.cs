using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace com.mxply.app.baseball.lib.common.enums
{
    public enum MovementType
    {
        // Offense

        Walk,
        IntentionedWalk,
        Hit1 = 0,
        Hit2 = 1,
        Hit3 = 2,
        HomeRun = 3,
        HitByPitch,
        FielderChoice,
        ErrorDefensor, //I can use NextBase in this case
        CatchersInterference,
        UmpiresInterference,
        Obstruction,

        StolenBase,
        BaseByMovement,
        
        // Defense
        Out,
        OutFly,
        OutLine,
        Assistance,
        Error,
        ErrorShoot,
        ErrorFly,
        Shoot,
        CaughtStolingBase,
        WildPitch,
        PassBall,
        KnockOut,
        KnockoutPassBall
    }
}
