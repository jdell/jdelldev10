package com.mxply.app.baseball.client.droid.model;


public enum MovementType
{
    // Offense

    Walk,
    IntentionedWalk,
    Hit1,
    Hit2,
    Hit3,
    HomeRun,
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
