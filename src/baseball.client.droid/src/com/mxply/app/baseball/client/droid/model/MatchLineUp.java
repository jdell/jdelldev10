package com.mxply.app.baseball.client.droid.model;

import java.util.UUID;

public class MatchLineUp {

	public static Class<MatchLineUp> MATCHLINEUP_CLASS = MatchLineUp.class;
	
	UUID id;
	UUID team;
	Position position;
	Person player;
	short number;
}
