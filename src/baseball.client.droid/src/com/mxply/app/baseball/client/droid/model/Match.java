package com.mxply.app.baseball.client.droid.model;

import java.util.Date;
import java.util.UUID;

public class Match {

	public static Class<Match> MATCH_CLASS = Match.class;
	
	UUID id;
	Date date;
	
	Team homeClub;
	Team guestClub;
	
	Person umpire1;
	Person umpire2;
	Person umpire3;
	Person umpire4;
	
	Person scoreTaker;
	
	Championship _championship;
	
	Stadium stadium;
	
	MatchStatus status;
	
	MatchLineUp[] lineUps;
}
